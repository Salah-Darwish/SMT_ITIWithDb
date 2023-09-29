using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SMT_ITIWithDb.Models;
using SMT_ITIWithDb.ViewModel;
using SMT_ITIWithDb.ViewModels;
{


    public class AccountController : Controller
    {
        private EmployeeContext context;
        public AccountController()
        {
            context = new EmployeeContext(); 
        }
        // Registration  => Add new user

        // Add New Data
        public IActionResult Register()
        {

            return View();
        }


        // Login    => Verfication of account (Authenticated user)
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginVM login)
        {
            // validate model
            if (ModelState.IsValid)
            {
                // Check in  DB
                if (login.IsOffice)
                {
                    // check in instructor table
                  Office office = context.Offices.SingleOrDefault(i => i.Name == login.Name && i.Location == login.Location);
                    if (office != null)
                    {
                        // Authenticated user
                        // Save session data
                        HttpContext.Session.SetInt32("Id", office.Id);
                        HttpContext.Session.SetString("Name", office.Name);
                        HttpContext.Session.SetString("Type", nameof( office));

                        // return view for user to start navigation in website
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        // unauthenticated user
                        ModelState.AddModelError("", "Wrong email or password");
                        return View(login);
                    }
                }
                else
                {
                    // check in student table
                    Employee employee = context.employees.SingleOrDefault(i => i.Email == login.Email && i.Password == login.Password);
                    if (employee != null)
                    {
                        // Authenticated user
                        // Save session data
                        HttpContext.Session.SetInt32("Id", employee.Id);
                        HttpContext.Session.SetString("Name", employee.Name);
                        HttpContext.Session.SetString("Type", nameof(Employee));


                        // return view for user to start navigation in website
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        // unauthenticated user
                        ModelState.AddModelError("", "Wrong email or password");
                        return View(login);
                    }
                }
            }
            else
            {
                return View(login);
            }

        }

        // Logout    => remove user data in session data
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}

