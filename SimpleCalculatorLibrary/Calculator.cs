using SimpleCalculator.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculatorLibrary
{
    public class Calculator
    {
        // Find the sum og two ints and return the result
        // non negative numbers only
        // even numbers only
        // throws suitable expresion if business rule is violated
        private ICalculatorRepo repo = null;
        public Calculator(ICalculatorRepo repo)
        { 
            this.repo = repo;
        }
        public int Sum(int a, int b)
        {
            if(a < 0 || b < 0)
                throw new NegativeInputException("Negative numbers are not allowed");
            if(a % 2 != 0 || b % 2 != 0)
                throw new OddInputException("Odd numbers are not allowed");
            //CalculatorRepo repo = new CalculatorRepo();
            repo.Save($"{a} + {b} = {a + b}");
            return a + b;
        }
    }
}
