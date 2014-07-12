using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTime.Models;

namespace TravelTime.Controllers
{
    public class MyChatController : Controller
    {
        public ActionResult Chat()
        {
            dbhandler objUser = new dbhandler();

            return View(objUser);
        }

    }
}
