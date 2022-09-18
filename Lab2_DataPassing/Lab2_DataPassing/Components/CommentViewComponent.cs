using Microsoft.AspNetCore.Mvc;

namespace Lab2_DataPassing.Components
{
    public class CommentViewComponent : ViewComponent
    {
        static List<string> history = new List<string>();

        public CommentViewComponent()
        {

        }

        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    var models = history;
        //    return await Task.FromResult((IViewComponentResult)View("AddComment",models));
        //}

        public IViewComponentResult Invoke(string comment)
        {
            if(!string.IsNullOrEmpty(comment))
                history.Add(comment);

            ViewData["CommentCount"] = history.Count;
            return View("~/Views/Components/_Comments.cshtml", history);
        }
    }
}
