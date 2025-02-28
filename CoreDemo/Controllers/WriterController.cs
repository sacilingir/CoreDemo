using Business.Concrete;
using Business.ValidationRules;
using CoreDemo.Models;
using DataAccess.Concrete;
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
		Context c = new Context();

		[Authorize]
		public IActionResult Index()
		{
			var usermail = User.Identity.Name;
			ViewBag.v = usermail;
			Context c = new Context();
			var writername = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterName).FirstOrDefault();
			ViewBag.v2 = writername;
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
			var usermail = User.Identity.Name;
			var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
			var writervalues = wm.TGetById(writerID);
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
        [HttpGet]
		public IActionResult WriterAdd()
		{
			return View();
		}

		[AllowAnonymous]
		[HttpPost]
		public IActionResult WriterAdd(AddProfileImage p)
		{
			Writer w = new Writer();
			if(p.WriterImage != null)
			{
				var extension = Path.GetExtension(p.WriterImage.FileName); //dosyanın uzantısını tutar
				var newimagename = Guid.NewGuid() + extension; //Guid.NewGuid(): Benzersiz bir rastgele dosya adı oluşturur
				var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename); //Directory.GetCurrentDirectory() : Projenin ana dizinini döndürür (örneğin, "C:\Projects\MyWebApp").
                                                                                                                         //Path.Combine(...): Yeni resmin tam yolunu oluşturur.
                var stream = new FileStream(location, FileMode.Create); //FileStream: Belirtilen yolda (location) yeni bir dosya oluşturur.
                p.WriterImage.CopyTo(stream);
				w.WriterImage = newimagename;
			}
			w.WriterMail = p.WriterMail;
			w.WriterName = p.WriterName;
			w.WriterPassword = p.WriterPassword;
			w.WriterStatus = p.WriterStatus;
			w.WriterAbout = p.WriterAbout;
			wm.TAdd(w);
			return RedirectToAction("Index","Dashboard");
		}


    }
}
