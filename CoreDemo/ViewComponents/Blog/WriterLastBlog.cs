using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Blog
{
	public class WriterLastBlog:ViewComponent
	{
		BlogManager bm = new BlogManager(new EfBlogRepository());

		public IViewComponentResult Invoke()
		{
			var values = bm.GetBlogListByWriter(6);
			return View(values);
		}
	}
}
