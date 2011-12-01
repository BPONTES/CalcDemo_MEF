using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using CalculatorInterfaces;

namespace SimpleCalculator
{
    [Export(typeof(ICalculator))]
    public class SimpleCalculator : ICalculator
    {
        public string Calculate(string input)
        {
            int left;
            int right;
            Char operation;
            int fn = FindFirstNonDigit(input); //finds the operator
            if (fn < 0) return "Could not parse command.";

            try
            {
                //separate out the operands
                left = int.Parse(input.Substring(0, fn));
                right = int.Parse(input.Substring(fn + 1));
            }
            catch
            {
                return "Could not parse command.";
            }

            operation = input[fn];

            foreach (Lazy<IOperation, IOperationData> i in operations)
            {
                if (i.Metadata.Symbol.Equals(operation)) return i.Value.Operate(left, right).ToString();
            }
            return "Operation Not Found!";
        }

        public IEnumerable<char> GetSupportedOperations()
        {
            return operations.Select(i => i.Metadata.Symbol);
        }

        private int FindFirstNonDigit(String s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (!(Char.IsDigit(s[i])) && (s[i] != '-' |  i != 0)) return i;
            }
            return -1;
        }

        [ImportMany]
        IEnumerable<Lazy<IOperation, IOperationData>> operations;

        public IEnumerable<Lazy<IOperation, IOperationData>> Operations
        {
            get
            {
                return operations;
            }
        }
    }
}
