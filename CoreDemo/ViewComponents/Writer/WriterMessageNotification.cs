﻿using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {

        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        public IViewComponentResult Invoke() {
            
            int id=2;
            var values = mm.GetInboxListByWriter(id);


            return View(values); 
        }
    }
}
