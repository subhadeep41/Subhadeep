using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using MyCalculatorServiceProxy;

namespace MyCalculatorServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1.MyCalculatorServiceProxy proxy;
            proxy = new Class1.MyCalculatorServiceProxy();
            Console.WriteLine("Client is running at " + DateTime.Now.ToString());
            Console.WriteLine("Sum of two numbers... 5+5 =" + proxy.Add(5, 5));
            Console.ReadLine();
        }
    }
}
