using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PLT_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Write a pseudocode to accept a number and display whether it is an even or
            //odd number

            Console.WriteLine("Enter the number :");
            int number = Convert.ToInt32(Console.ReadLine());

            if (number % 2 == 0)
                Console.WriteLine("The number is even");
            else
                Console.WriteLine("The number is odd");

            Console.ReadLine();
        }
    }
}
