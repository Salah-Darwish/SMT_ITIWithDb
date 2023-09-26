using Microsoft.AspNetCore.Mvc;
using SMT_ITIWithDb.Models;

namespace SMT_ITIWithDb.Controllers
{
    public class OfficeController : Controller
    { 
    private EmployeeContext context;
    public OfficeController()
    {
        context = new EmployeeContext();
    }
        public IActionResult Index()
        {
          List<Office>offices=context.Offices.ToList();
            return View(offices);
        }
        public IActionResult Details(int id)
        {
            Office office=context.Offices.SingleOrDefault(o=>o.Id==id);
           return View(office);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost   ]
        public IActionResult Add(Office office)
        {
            context.Offices.Add(office);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Office office = context.Offices.SingleOrDefault(o =>o.Id == id); 

            return View(office); 
        }
        [HttpPost]
        public IActionResult Edit(Office office)
        {
            context.Offices.Update(office);
            context.SaveChanges();
            return RedirectToAction("Index"); 
        }
        public IActionResult Delete(int id)
        {
            Office office = context.Offices.SingleOrDefault(o => o.Id == id);
            context.Offices.Remove(office);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
