using System;
using System.Collections.Generic;
using System.Text;
using MyCalculatorServiceHost;
using System.ServiceModel;
using MyCalculatorService;

namespace MyCalculatorServiceProxy
{
    public class Class1
    {
        public class MyCalculatorServiceProxy :
            //WCF create proxy for ISimpleCalculator using ClientBase
        ClientBase<ISimpleCalculator>, ISimpleCalculator
        {
            public int Add(int num1, int num2)
            {
                //Call base to do funtion
                return base.Channel.Add(num1, num2);
            }
        }
    }
}
