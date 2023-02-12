using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLT_22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  Write a pseudocode to check if the string is a palindrome

            Console.WriteLine("Enter a string: ");
            string str = Console.ReadLine();

            int flag = 0;

            for (int i = 0; i < str.Length / 2; i++)
            {
                if (str[i] != str[str.Length - i - 1])
                {
                    flag = 1;
                    break;
                }
            }

            if (flag == 1)
            {
                Console.WriteLine("The string is not a palindrome.");
            }
            else
            {
                Console.WriteLine("The string is a palindrome.");
            }
        }
    }
}
