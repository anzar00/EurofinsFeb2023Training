using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLT_20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Write a pseudocode to x to the power of n) Accept X and n. Display the result.

            Console.WriteLine("Enter X: ");
            int x = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter n: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int result = 1;

            if (x==0 && n==0)
            {
                Console.WriteLine("The result is undefined");
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    result *= x;
                }
                
                Console.WriteLine("The result is: " + result);

                Console.ReadKey();
            }

        }
    }
}
