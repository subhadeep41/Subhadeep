using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndiaLance.Models;
using System.Data.Entity;
using IndiaLance.UtilityDatabase;
using System.Configuration;
using System.Collections;

namespace IndiaLance.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        ProjectType obj = new ProjectType();
        List<ProjectType> projectlist1 = new List<ProjectType>();
        List<string> itlist = null;
        List<string> designmedia = null;
        List<string> dataentry = null;
        List<String> Engg = null;
        Commonclass itobj = new Commonclass();
        public ActionResult Home()
        {
            obj = DataProvider.getdatabyid(1002);
            itlist = DataProvider.getAllITTech();
            designmedia = DataProvider.getAllDesignmedia();
            dataentry = DataProvider.getAllDataEntry();
            Engg = DataProvider.getAllEngg();
            

            //ITTech part
            List<Commonclass> obj1 = new List<Commonclass>();
            for (int i = 1; i <= itlist.Count; i++)
            {
                itobj = new Commonclass();
                itobj.section = itlist[i-1];
                itobj.posts = (DataProvider.itTech(i)).Posts;
                itobj.projects = (DataProvider.itTech(i)).Projects;
                obj1.Add(itobj);
            }
            ViewData["itdetails"] = obj1;

            //Designmedia part
            itobj = null;
            List<Commonclass> obj2 = new List<Commonclass>();
            for (int i = 1; i <= designmedia.Count; i++)
            {
                itobj = new Commonclass();
                itobj.section = designmedia[i - 1];
                itobj.posts = (DataProvider.dmedia(i)).Posts;
                itobj.projects = (DataProvider.dmedia(i)).Projects;
                obj2.Add(itobj);
            }
            ViewData["designmedia"] = obj2;

            //Dataentry part
            itobj = null;
            List<Commonclass> obj3 = new List<Commonclass>();
            for (int i = 1; i <= dataentry.Count; i++)
            {
                itobj = new Commonclass();
                itobj.section = dataentry[i - 1];
                itobj.posts = (DataProvider.dentry(i)).Posts;
                itobj.projects = (DataProvider.dentry(i)).Projects;
                obj3.Add(itobj);
            }
            ViewData["dataentry"] = obj3;

            //Engg part
            itobj = null;
            List<Commonclass> obj4 = new List<Commonclass>();
            for (int i = 1; i <= Engg.Count; i++)
            {
                itobj = new Commonclass();
                itobj.section = Engg[i - 1];
                itobj.posts = (DataProvider.Engg(i)).Posts;
                itobj.projects = (DataProvider.Engg(i)).Projects;
                obj4.Add(itobj);
            }
            ViewData["engg"] = obj4;
                //string settings = ConfigurationManager.ConnectionStrings["DataProvider"].ToString();
                //ProjectsContext db = new ProjectsContext(settings);

                return View(obj);
        }
        public ActionResult Details()
        {
            return View();
        }
    }
}
