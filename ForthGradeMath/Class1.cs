using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

using CalculatorInterfaces;

namespace SimpleCalculator
{
    [Export(typeof(IOperation))]
    [ExportMetadata("Symbol", '*')]
    class Multiple : IOperation
    {
        public int Operate(int left, int right)
        {
            return left * right;
        }
    }
}
