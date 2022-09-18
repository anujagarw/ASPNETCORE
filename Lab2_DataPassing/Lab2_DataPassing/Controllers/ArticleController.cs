using Lab2_DataPassing.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab2_DataPassing.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult CommentHistory()
        {
            return View();
        }

        public IActionResult PostComment(ArticleModel model)
        {
            if (ModelState.IsValid)
            {
                ViewData["comment"] = model.Comments;
            }

            return View("~/Views/Article/CommentHistory.cshtml");
        }
    }
}
