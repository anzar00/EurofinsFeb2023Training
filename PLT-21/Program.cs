using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLT_21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Write a pseudocode to display the reverse of a string.

            Console.WriteLine("Enter a string: ");
            string str = Console.ReadLine();

            string reverse = "";

            for (int i = str.Length - 1; i >= 0; i--)
            {
                reverse += str[i];
            }
            Console.WriteLine(str.Length);

            Console.WriteLine("The reverse of the string is: " + reverse);

            Console.ReadKey();
        }
    }
}
