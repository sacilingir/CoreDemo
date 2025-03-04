﻿using DataAccess.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            Context c = new Context();
            ViewBag.v1 = c.Blogs.Count();ToString();
            ViewBag.v2 = c.Blogs.Where(x => x.WriterId == 7).Count();
            ViewBag.v3 = c.Categories.Count();ToString();

            return View();
        }
    }
}
