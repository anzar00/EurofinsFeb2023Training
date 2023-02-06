using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// C# code to display the 1st, 2nd and 4th multiple of 7 which gives the remainder 1 when divided by 2,3,4,5, and 6.

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 7;
            int count = 0;
            int cal = 0;

            while (true)
            {
                cal = cal + i;
                if (cal % 2 == 1 && cal % 3 == 1 && cal % 4 == 1 && cal % 5 == 1 && cal % 6 == 1)
                {
                    count++;
                    if (count == 1 || count == 2 || count == 4)
                        Console.WriteLine(cal);
                }
            }
        }
    }
}

