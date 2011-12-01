using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorInterfaces
{
    public interface ICalculator
    {
        String Calculate(String input);
        IEnumerable<char> GetSupportedOperations();
    }

    public interface IOperation
    {
        int Operate(int left, int right);
    }

    public interface IOperationData
    {
        Char Symbol { get; }
    }
}
