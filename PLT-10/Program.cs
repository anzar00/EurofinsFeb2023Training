using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PLT_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Write a pseudocode to find the reverse of a number. Store the reverse value 
            //in a different variable.Display the reverse.            

            int n = 0;
            int reverse = 0;

            Console.WriteLine("Enter N: ");
            n = Convert.ToInt32(Console.ReadLine());

            while (n != 0)
            {
                reverse = reverse * 10;
                reverse = reverse + n % 10;
                n = n / 10;
            }

            Console.WriteLine("Reverse of the number is {0}", reverse);
            Console.ReadKey();
        }
    }
}
