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

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(NewPinVM pinVM)
        {
            return RedirectToAction("Index");
        }
    }
}