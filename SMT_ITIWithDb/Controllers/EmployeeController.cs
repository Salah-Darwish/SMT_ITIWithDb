using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMT_ITIWithDb.Models;

namespace SMT_ITIWithDb.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeContext context;

        public dynamic Offices { get; private set; }

        public EmployeeController()
        {
            context = new EmployeeContext();
        }
        public IActionResult Index()
        {
            List<Employee>Employees = context.employees.ToList();
            return View(Employees);
        }
        public IActionResult Details(int id) { 

            Employee employee=context.employees.Include(e=>e.Office).SingleOrDefault((e => e.Id == id));
            if(employee==null)
            {
                return Content("Error");
            }
            return View(employee);
        }
        public IActionResult NewForm()
        {
            List<Office> Off = context.Offices.ToList();
            ViewBag.Off = Off; 
            return View();
        }
        public IActionResult AddToDB(Employee employee)
        {
            context.employees.Add(employee);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult EditForm(int id)
        {
            Employee employee = context.employees.SingleOrDefault(c => c.Id == id);

            ViewBag.Off = context.Offices.ToList();
            return View(employee);
        }

            public IActionResult EditInDB(Employee employee)
            {
                Employee oldEmployee = context.employees.SingleOrDefault(c => c.Id == employee.Id);

                oldEmployee.Name = employee.Name;
                oldEmployee.Age = employee.Age;
                oldEmployee.Salary = employee.Salary;
                oldEmployee.Email = employee.Email;
               
                oldEmployee.Office_Id = employee.Office_Id;

                context.SaveChanges();
                return RedirectToAction("Index");
            }

        public IActionResult Delete(int id)
        {
            Employee employee = context.employees.SingleOrDefault(c => c.Id == id);
            context.employees.Remove(employee);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
