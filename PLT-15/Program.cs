using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLT_15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Write a pseudocode to accept a decimal number. Display it in the binary form. 

            Console.WriteLine("Enter a decimal number: ");
            int num = Convert.ToInt32(Console.ReadLine());

            int[] binary = new int[100];
            int i = 0;

            while (num > 0)
            {
                binary[i] = num % 2;
                num /= 2;
                i++;
            }

            Console.Write("The binary form of the number is: ");
            for (int j = i - 1; j >= 0; j--)
            {
                Console.Write(binary[j]);
            }

            Console.ReadKey();
        }
    }
}
