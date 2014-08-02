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
}