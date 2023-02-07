using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLT_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Write a code to accept two numbers.Display the two numbers. Swap the
            //two numbers and display them again.

            Console.WriteLine("Enter the first number :");
            int firstNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the second number :");
            int secondNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"First number is - {firstNumber}");
            Console.WriteLine($"Second number is - {secondNumber}");

            int temp = firstNumber;
            firstNumber = secondNumber;
            secondNumber = temp;

            Console.WriteLine($"First number is - {firstNumber}");
            Console.WriteLine($"Second number is - {secondNumber}");

            Console.ReadLine();
        }
    }
}
