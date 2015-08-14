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
            return View(context.Pins.ToList());
        }

        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(Pin pin)
        {
            context.Pins.Attach
            return RedirectToAction("Index");
        }

        public ActionResult GetImage(int ID)
        {
            return File(context.Pins.FirstOrDefault(x => x.ID == ID).Image, "image");
        }
    }
}