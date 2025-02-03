using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entitiy.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Writer p)
        {
            WriterValidator vw = new WriterValidator();
            ValidationResult results = vw.Validate(p);

            ModelState.Clear();
            if (results.IsValid)
            {
                p.WriterStatus = true;
                p.WriterAbout = " Test Deneme... ";
                p.WriterImage = "Daha sonra eklenecek..";
                wm.WriterAdd(p);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            return View();
            
        }
    }
}
