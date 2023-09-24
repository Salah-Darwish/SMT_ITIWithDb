using Microsoft.AspNetCore.Mvc;
using SMT_ITIWithDb.Models;

namespace SMT_ITIWithDb.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeContext context; 
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

            Employee employee=context.employees.Where(e=> e.Id == id).SingleOrDefault();
            if(employee==null)
            {
                return Content("Error");
            }
            return View(employee);
        }
        public IActionResult NewForm()
        {
            return View();
        }
        public IActionResult AddToDB(Employee employee)
        {
            context.employees.Add(employee);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
