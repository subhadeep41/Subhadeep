using System;
using System.Collections.Generic;
using System.Text;

namespace MyCalculatorService
{
    public class SimpleCalculator : ISimpleCalculator
    {
        public int Add(int num1, int num2)
        {
            return num1 + num2;
        }

    }
}
