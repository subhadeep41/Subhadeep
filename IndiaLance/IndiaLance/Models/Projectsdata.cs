using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Linq;

namespace IndiaLance.Models
{
    public class ProjectsContext : DataContext
    {
        public Table<ItTech> ItTechdb { get; set; }

        public ProjectsContext(string connectionString):base(connectionString) { }

        public ProjectsContext(System.Data.IDbConnection connection) : base(connection) { }

    }
    public class ProjectType
    {
        public int ID { get; set; }

        public string ITTech { get; set; }

        public string Designmedia { get; set; }

        public string Dataentry { get; set; }

        public string Engg { get; set; }
    }
    public class ItTech
    {
        public int ID { get; set; }
        public string Projects { get; set; }
        public int Posts { get; set; }
    }
    public class Commonclass
    {
        public string section { get; set; }
        public int posts { get; set; }
        public string projects { get; set; }
    }

    public class JavaSec
    {
        public int projectId { get; set; }
        public int amount { get; set; }
        public string details { get; set; }
        public string isValid { get; set; }
        public int attachmentid { get; set; }
    }
}