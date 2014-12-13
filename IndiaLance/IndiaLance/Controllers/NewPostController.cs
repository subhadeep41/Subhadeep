using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using IndiaLance.Models;
using IndiaLance.UtilityDatabase;

namespace IndiaLance.Controllers
{
    public class NewPostController : Controller
    {
        List<string> itlist = null;
        List<string> designmedia = null;
        List<string> dataentry = null;
        List<string> Engg = null;
        //IndiaLanceServiceClient clientobj = new IndiaLanceServiceClient();
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
            itlist = DataProvider.getAllITTech();
            designmedia = DataProvider.getAllDesignmedia();
            dataentry = DataProvider.getAllDataEntry();
            Engg = DataProvider.getAllEngg();
            List<SelectListItem> states = new List<SelectListItem>();
            switch (id)
            {
                case "1":
                    states.Add(new SelectListItem { Text = "Select", Value = "0" });
                    for (int i = 0; i < itlist.Count; i++)
                    {
                        if (itlist[i] != "")
                        states.Add(new SelectListItem { Text = itlist[i].ToString(), Value = Convert.ToString(i+1) });
                    }
                    break;
                case "2":
                    states.Add(new SelectListItem { Text = "Select", Value = "0" });
                    for (int i = 0; i < designmedia.Count; i++)
                    {
                        if (designmedia[i] != "")
                        states.Add(new SelectListItem { Text = designmedia[i].ToString(), Value = Convert.ToString(i + 1) });
                    }
                    break;
                case "3":
                    states.Add(new SelectListItem { Text = "Select", Value = "0" });
                    for (int i = 0; i < dataentry.Count; i++)
                    {
                        if (dataentry[i] != "")
                        states.Add(new SelectListItem { Text = dataentry[i].ToString(), Value = Convert.ToString(i + 1) });
                    }
                    break;
                case "4":
                    states.Add(new SelectListItem { Text = "Select", Value = "0" });
                    for (int i = 0; i < Engg.Count; i++)
                    {
                        if (Engg[i] != "")
                        {
                            states.Add(new SelectListItem { Text = Engg[i].ToString(), Value = Convert.ToString(i + 1) });
                        }
                    }
                    break;
            }
            return Json(new SelectList(states, "Value", "Text"));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public void getdatait(string domain, string techtype, int id,int amount, string details, string isvalid, string attachments)
        {
            try
            {
                if (domain == "IT Technology")
                {
                    var js = new JavaScriptSerializer();
                    var result = js.DeserializeObject(attachments);
                    int attachid = Convert.ToInt32(((object[])(((object[])(result))[0]))[1]);
                    string attachdata = Convert.ToString(((object[])(((object[])(result))[0]))[0]);
                    JavaSec obj1 = new JavaSec();
                    obj1.projectId = id;
                    obj1.amount = amount;
                    obj1.details = details;
                    obj1.isValid = isvalid;
                    obj1.attachmentid = attachid;
                    DataProvider.InsertJava(obj1, techtype);
                    DataProvider.InsertAttachments(attachid, attachdata);
                }
            }
            catch (Exception ex)
            { }
        }

        public ActionResult uploadhelper()
        {
            return View();
        }
    }
}
