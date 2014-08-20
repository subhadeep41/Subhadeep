using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IndiaLance.Controllers
{
    public class BlogController : Controller
    {
        //
        // GET: /Blog/

        public ActionResult LiveChat()
        {
            var nameCookie = Request.Cookies.Get("name");

           // if (nameCookie == null)
               // Response.Redirect("~/Default.aspx?returnUrl=" + Server.UrlEncode(Request.FilePath));
            return View();
        }

    }
}
