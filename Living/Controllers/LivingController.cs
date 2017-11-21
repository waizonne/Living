using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Living.Controllers
{
    public class LivingController : Controller
    {
        // GET: Living
        public ActionResult Test()
        {
            ViewBag.Name = "Abhisit";
            ViewBag.Age = 30;

            return View();
        }

        public ActionResult Test2()
        {
            return View();
        }

        public ActionResult Example()
        {
            return View();
        }
    }
}