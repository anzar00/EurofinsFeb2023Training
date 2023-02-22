using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator.DataAccess
{
    public class CalculatorRepo : ICalculatorRepo
    {
        public bool Save(string data)
        {
            // logic to save data in to data store
            File.WriteAllText("X:\\Training\\Day 13\\calculatorresult.txt", data);
            return true;
        }
    }
}
