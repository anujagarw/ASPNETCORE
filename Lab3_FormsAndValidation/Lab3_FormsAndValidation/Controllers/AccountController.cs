using Lab3_FormsAndValidation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Lab3_FormsAndValidation.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(UserModel model)
        {
            if (ModelState.IsValid)
            {
                //To Do:
                TempData["Message"] = "Your account has been created!";
                //TempData["Name"] = model.Name;

                //string strData = JsonSerializer.Serialize(model);
              //
                return RedirectToAction("Message");
            }
            return View();
        }

        public IActionResult Message()
        {
            //string message = (string)TempData["Message"]; //read once
            //string name = (string)TempData.Peek("Name"); //read many


            return View();
        }
    }
}
