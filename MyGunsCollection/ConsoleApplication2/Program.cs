using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Myclass test = new Myclass();
            Console.Read();
        }
        public class MyBaseClass
        {
            protected MyBaseClass()
            {
                Console.WriteLine("Base Constructor hit");
            }
        }

        public class Myclass : MyBaseClass
        {
            static Myclass()
            {
                Console.WriteLine("Child static Constructor hit");
            }

            public Myclass()
                : base()
            {
                Console.WriteLine("Child Constructor hit");
            }
        }

    }
}
