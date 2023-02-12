using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLT_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Write a pseudocode to find the sum of all the prime numbers in the range n to m. 
            // Display each prime number and also the final sum.

            Console.WriteLine("Enter n: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter m: ");
            int m = Convert.ToInt32(Console.ReadLine());

            int sum = 0;

            //Find prime numbers from n to m and add them to sum

            for (int i = n; i <= m; i++)
            {
                bool isPrime = true;

                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    Console.WriteLine(i);
                    sum += i;
                }
            }

            Console.WriteLine("The sum of all the prime numbers is: " + sum);
            Console.ReadKey();


        }
    }
}
