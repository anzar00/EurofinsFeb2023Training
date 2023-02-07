using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLT_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Write a pseudocode to accept a double value. Separate the whole value from the
            //fractional value and store them in two variables. Display the same. 

            Console.WriteLine("Enter the double value :");
            double doubleValue = Convert.ToDouble(Console.ReadLine());

            int wholeValue = (int)doubleValue;
            double fractionalValue = doubleValue - wholeValue;

            Console.WriteLine($"Whole value is - {wholeValue}");
            Console.WriteLine($"Fractional value is - {fractionalValue}");

            Console.ReadLine();
        }
    }
}
