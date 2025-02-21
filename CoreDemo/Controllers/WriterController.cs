using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entitiy.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	
	public class WriterController : Controller
	{
		WriterManager wm = new WriterManager(new EfWriterRepository());

		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult WriterProfile()
		{
			return View();
		}
		[AllowAnonymous]
		public IActionResult Test()
		{
			return View();
		}
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
		{
			return PartialView();
		}
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
		{
			return PartialView();
		}

        [AllowAnonymous]
		[HttpGet]
		public IActionResult WriterEditProfile()
		{
			var writervalues = wm.TGetById(2);
			return View(writervalues);
		}
        [AllowAnonymous]
        [HttpPost]
		public IActionResult WriterEditProfile(Writer p)
		{
			WriterValidator wv = new WriterValidator();
			ValidationResult result = wv.Validate(p);
			if (result.IsValid)
			{
				wm.TUpdate(p);
				return RedirectToAction("Index", "Dashboard");
			}
            else
            {
                foreach (var item in result.Errors)
                {
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
			return View();

        }

		[AllowAnonymous]
		[HttpPost]
		public IActionResult WriterAdd()
		{
			return View();
		}


    }
}
