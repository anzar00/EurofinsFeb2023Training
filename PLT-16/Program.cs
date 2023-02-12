using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLT_16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Write a pseudocode to accept a binary number and display it in the decimal 
            // form.

            Console.WriteLine("Enter a binary number: ");
            int num = Convert.ToInt32(Console.ReadLine());

            int decimalNum = 0;
            int baseNum = 1;
            int temp = num;

            while (temp > 0)
            {
                int lastDigit = temp % 10;
                temp /= 10;

                decimalNum += lastDigit * baseNum;
                baseNum *= 2;
            }

            Console.WriteLine("The decimal form of the number is: " + decimalNum);

            Console.ReadKey();
        }
    }
}
