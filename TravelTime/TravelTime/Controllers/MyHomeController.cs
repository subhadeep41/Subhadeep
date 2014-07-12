using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelTime.Controllers
{
    public class MyHomeController : Controller
    {
        //
        // GET: /MyHome/

        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Railway()
        {
            return View();
        }
        public ActionResult MapFinder()
        {
            return View();
        }
    }
}
