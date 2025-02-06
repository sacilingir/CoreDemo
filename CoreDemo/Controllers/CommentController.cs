using Business.Concrete;
using DataAccess.EntityFramework;
using Entitiy.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialAddComment(Comment c)
        {
            c.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.CommentStatus = true;
            c.BlogId = 2;
            cm.CommentAdd(c);
            return PartialView();
        }
        public PartialViewResult PartialCommentListByBlog(int id)
        {

           var values = cm.GetList(id);
            return PartialView(values);
        }
    }
}
