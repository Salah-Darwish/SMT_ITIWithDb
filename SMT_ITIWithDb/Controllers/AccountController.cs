using Microsoft.AspNetCore.Mvc;

namespace SMT_ITIWithDb.Controllers
{
    public class AccountController : Controller
    {
        //Registration =>add new user 

        // Add new Data
        public IActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login() 
        { 
        return View();
        }

        [HttpPost]
        //public IActionResult Login()
        //{
        //  // save session data
        //   //return view for user to start navigtion in website

            
        //}




        // Login => Verfication Account (Authenticated user)




        // logout => remove user data in session data
        public IActionResult Index()
        {
            return View();
        }
    }
}
