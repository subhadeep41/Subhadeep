using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace IndiaLance.Controllers
{
    public class NewPostController : Controller
    {
        //
        // GET: /NewPost/

        public ActionResult NewPostPage()
        {
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "Select", Value = "0" });
            li.Add(new SelectListItem { Text = "IT Technology", Value = "1" });
            li.Add(new SelectListItem { Text = "Design Media", Value = "2" });
            li.Add(new SelectListItem { Text = "Data Entry", Value = "3" });
            li.Add(new SelectListItem { Text = "Enggineering", Value = "4" });
            ViewData["techtype"] = li;
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GetStates(string id)
        {
            List<SelectListItem> states = new List<SelectListItem>();
            switch (id)
            {
                case "1":
                    states.Add(new SelectListItem { Text = "Select", Value = "0" });
                    states.Add(new SelectListItem { Text = "ANDAMAN & NIKOBAR ISLANDS", Value = "1" });
                    states.Add(new SelectListItem { Text = "ANDHRA PRADESH", Value = "2" });
                    states.Add(new SelectListItem { Text = "ARUNACHAL PRADESH", Value = "3" });
                    states.Add(new SelectListItem { Text = "ASSAM", Value = "4" });
                    break;
            }
            return Json(new SelectList(states, "Value", "Text"));
        }

    }
}
