using Interest.Models;
using Microsoft.AspNet.Identity;
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
           var list = context.Pins.ToList().Select(p => new { p.ID, p.url, p.ImageLink, p.Notes }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        //[HttpGet]
        //public ActionResult New()
        //{
        //    return View();
        //}

        //   [ResponseType(typeof(Pin))]
        public ActionResult Delete(int ID)
        {
            Pin pin = context.Pins.FirstOrDefault(p => p.ID == ID);
            context.Pins.Attach(pin);
            context.Pins.Remove(pin);
            context.SaveChanges();
            return new EmptyResult();
        }   

        public ActionResult New(string ImageLink, string url, string Notes)
        {
            string ID = System.Web.HttpContext.Current.User.Identity.GetUserId();
            Pin pin = new Pin();
            if (!url.Contains("www."))
                url = "www." + url;
            if (!url.Contains("http://"))
                url = "http://" + url;
            pin.url = url;
            pin.Notes = Notes;
            pin.Image = Pin.GetImageByteArray(ImageLink);
            pin.Publisher = context.Users.FirstOrDefault(p => p.Id == ID);
            context.Pins.Add(pin);
            context.SaveChanges();
            var newPin = context.Pins.FirstOrDefault(p => p.url == pin.url && p.Notes == pin.Notes);
            return Json(new { newPin.ID, newPin.ImageLink, newPin.Notes, newPin.url }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetImage(int ID)
        {
            return File(context.Pins.FirstOrDefault(x => x.ID == ID).Image, "image");
        }
    }
}