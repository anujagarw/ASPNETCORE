using Microsoft.AspNetCore.Mvc;
using RoutingAndNavigation_Ass11Sep22.Areas.Admin.Models;
using System.Reflection;

namespace RoutingAndNavigation_Ass11Sep22.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        public IActionResult AdminLogin(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                //To Do:
                if (model.Username == "admin")
                {
                    TempData["MessageAdmin"] = "Welcome to Admin Team," + model.Username;
                    //HttpContext.Session.SetString("Admin", model.Username);
                    return RedirectToAction("Dashboard", "Dashboard");
                }
                else
                { 
                    //TODO - show error
                }

            }
            return View();
        }
    }
}
