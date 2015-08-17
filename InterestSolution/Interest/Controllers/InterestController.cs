using Interest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interest.Controllers
{
    public class InterestController : Controller
    {
        InterestDbContext context = new InterestDbContext();

        public ActionResult HomePage()
        {
            return View();
        }

        public ActionResult List()
        {
           var list = context.Pins.ToList().Select(p => new { p.url, p.ImageLink, p.Notes }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        //[HttpGet]
        //public ActionResult New()
        //{
        //    return View();
        //}

     //   [ResponseType(typeof(Pin))]
        public ActionResult New(Pin pin)
        {   
            if (pin != null) { 
            context.Pins.Attach(pin);
            context.Pins.Add(pin);
            }
            return RedirectToAction("Index");
        }

        public ActionResult GetImage(int ID)
        {
            return File(context.Pins.FirstOrDefault(x => x.ID == ID).Image, "image");
        }
    }
}