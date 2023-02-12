using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLT_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Write a pseudocode to display a number in words.
            //Ex. 270176
            //Output: Two Seven Zero One Seven Six

            int n = 0;
            int digit = 0;
            int i = 0;
            int[] digits = new int[10];

            Console.WriteLine("Enter N: ");
            n = Convert.ToInt32(Console.ReadLine());

            while (n != 0)
            {
                digit = n % 10;
                digits[i] = digit;
                n = n / 10;
                i++;
            }

            for (int j = i - 1; j >= 0; j--)
            {
                switch (digits[j])
                {
                    case 0:
                        Console.Write("Zero ");
                        break;
                    case 1:
                        Console.Write("One ");
                        break;
                    case 2:
                        Console.Write("Two ");
                        break;
                    case 3:
                        Console.Write("Three ");
                        break;
                    case 4:
                        Console.Write("Four ");
                        break;
                    case 5:
                        Console.Write("Five ");
                        break;
                    case 6:
                        Console.Write("Six ");
                        break;
                    case 7:
                        Console.Write("Seven ");
                        break;
                    case 8:
                        Console.Write("Eight ");
                        break;
                    case 9:
                        Console.Write("Nine ");
                        break;
                }
            }

            Console.ReadKey();
            
        }
    }
}
