using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GPSInspector.Models;

namespace GPSInspector.Controllers
{
    public class MainControlController : Controller
    {
        //
        // GET: /MainControl/

        public ActionResult Inspect()
        {
            User obj = new User();
            
            return View();
        }

    }
}
