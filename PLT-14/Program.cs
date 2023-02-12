using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLT_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Write a pseudocode to find the factorial of a given number. 0! is always 1. 
            // Factorial of a negative number is not possible.

            Console.WriteLine("Enter a number: ");
            int num = Convert.ToInt32(Console.ReadLine());

            int result = 1;

            if (num < 0)
            {
                Console.WriteLine("Factorial of a negative number is not possible.");
            }
            else if(num == 0)
            {
                Console.WriteLine("The factorial of 0 is 1.");
            }
            else
            {
                for (int i = 1; i <= num; i++)
                {
                    result *= i;
                }
                Console.WriteLine("The factorial of " + num + " is " + result);
            }

            Console.ReadKey();
        }
    }
}
