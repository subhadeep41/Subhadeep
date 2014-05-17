using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TChat.Controllers
{
    public class ChatHomeController : Controller
    {
        //
        // GET: /ChatHome/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Chathome(string name)
        {
            ViewBag.name = name;
            return View("ChatHome");
        }

    }
}
