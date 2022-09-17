using Microsoft.AspNetCore.Mvc;
using RoutingAndNavigation_Ass11Sep22.Areas.User.Models;

namespace RoutingAndNavigation_Ass11Sep22.Areas.User.Controllers
{
    [Area("User")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                //To Do:
                if(model.Username == "user")
                {
                    TempData["MessageUser"] = "Welcome to User Team:" + model.Username;
                    //HttpContext.Session.SetString("User", model.Username);

                    return RedirectToAction("Dashboard", "User");
                }                

            }
            return View();
        }

        public IActionResult Dashboard()
        {
            string userMessage = (string)TempData["MessageUser"];
            return View();
        }

        public IActionResult Profile()
        {
            string userMessage = (string)TempData["MessageUser"];
            return View();
        }
    }
}
