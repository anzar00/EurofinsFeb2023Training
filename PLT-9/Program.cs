using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLT_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Write a pseudocode to find the sum of all odd numbers from 1 to N. Accept N.
            // Display the sum. 

            int i, n = 0;
            int sum = 0;

            Console.WriteLine("Enter N: ");
            n = Convert.ToInt32(Console.ReadLine());

            for (i = 1; i <= n; i++)
            {
                if (i % 2 != 0)
                {
                    sum = sum + i;
                }
            }

            Console.WriteLine("Sum of all odd numbers from 1 to {0} is {1}", n, sum);
            Console.ReadKey();
        }
    }
}
