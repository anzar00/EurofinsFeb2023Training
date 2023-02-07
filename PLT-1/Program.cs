using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLT_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Write a code to accept principle, rate of interest and time.
            //Calculate simple interest and display the same.

            Console.WriteLine("Enter the principle amount :");
            int principle = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the rate of interest :");
            int rate = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the time (in years) :");
            int time = Convert.ToInt32(Console.ReadLine());

            int simpleInterest = (principle * rate * time) / 100;

            Console.WriteLine($"Simple interest is - {simpleInterest}");

            Console.ReadLine();
        }
    }
}
