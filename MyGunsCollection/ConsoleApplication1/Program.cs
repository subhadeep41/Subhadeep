using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("ID:");
                int Id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Name:");
                string Name = Console.ReadLine();
                Console.WriteLine("Age:");
                int Age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Department:");
                string Department = Console.ReadLine();
                Console.WriteLine("Years Experience:");
                int YearsExperience = Convert.ToInt32(Console.ReadLine());
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occured: " + ex.Message);
            }
        }
        public class Employee : IEmployee
        {
            int id;
        }
    }
    public interface IEmployee
    {
        int Id { get; set; }
        string Name { get; set; }
        int Age { get; set; }
        string Department { get; set; }
        int YearsExperience { get; set; }

        //Prints the property value like - Age:33
        void Print(string propertyName);

        void Set(string propertyName, object value);
    }
}
