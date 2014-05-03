using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace MyCalculatorService
{
    [ServiceContract()]
    public interface ISimpleCalculator
    {
        [OperationContract()]
        int Add(int num1, int num2);
    }
}
