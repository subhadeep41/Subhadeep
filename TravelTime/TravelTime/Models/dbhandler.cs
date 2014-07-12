using System.Data.Entity;

namespace TravelTime.Models
{
    public class dbhandler : DbContext
    {
        public DbSet<Users> user { get; set; }
    }
}