using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IndiaLance.Models
{
    //public class Users
    //{
    //    public Users() { }
    //    public string Name { get; set; }
    //    public string Email { get; set; }
    //    public int ID { get; set; }
    //}
    public class ProjectType
    {
        public int ID { get; set; }

        public string ITTech { get; set; }

        public string Designmedia { get; set; }

        public string Dataentry { get; set; }

        public string Engg { get; set; }
    }
    
}