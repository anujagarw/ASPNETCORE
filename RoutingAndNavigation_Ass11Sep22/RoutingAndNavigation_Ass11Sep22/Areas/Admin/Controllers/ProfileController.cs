using Microsoft.AspNetCore.Mvc;

namespace RoutingAndNavigation_Ass11Sep22.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProfileController : Controller
    {
        public IActionResult AdminProfile()
        {
            return View();
        }
    }
}
