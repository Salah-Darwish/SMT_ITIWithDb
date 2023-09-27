using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SMT_ITIWithDb.Models;
using SMT_ITIWithDb.ViewModel;

namespace SMT_ITIWithDb.Controllers
{
    public class ValidationController : Controller
    {
        private EmployeeContext context; 
        public ValidationController()
        {
            context= new EmployeeContext();

        }
        public IActionResult Index()
        {
            List<Employee>employees=context.employees.ToList(); 
            return View(employees);
        }
        [HttpGet]
        public IActionResult Add()
        {
            EmployeeVMcs employee = new EmployeeVMcs()
            {
                Offices = new SelectList(context.Offices, "Id", "Name")
            }; 
            return View(employee);
        }
        [HttpPost]
        public IActionResult Add(EmployeeVMcs employee )
        {
            if (ModelState.IsValid)
            {
                Employee newEmployee = new Employee()
                {
                    Name = employee.Name,
                    Age= employee.Age,
                    Salary= employee.Salary,
                    Img= employee.Img,
                    Email= employee.Email,
                    Password= employee.Password,
                    Office_Id= employee.Office_Id,
                };
                context.employees.Add(newEmployee); 
                context.SaveChanges();
                return RedirectToAction("Index", "Employee");
            }
            employee.Offices = new SelectList(context.Offices,"Id","Name");
            return View(employee);
            
        }
       
    
    }
}
