using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PLT_25a
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Write the code to generate the following output. Accept N:

            //1
            //-4 9
            //-16 25 -36
            //: 
            //: 
            //N rows


            //Console.WriteLine("Enter N: ");
            //int n = Convert.ToInt32(Console.ReadLine());

            //int number = 1;
            //for (int i = 1; i <= n; i++)
            //{
            //    for (int j = 1; j <= i; j++)
            //    {
            //        if (j==1 & i==1) Console.Write(number);
            //        else
            //            Console.Write((number * number) * (j % 2 != 0 ? -1 : 1) + " ");
            //        number++;
            //    }
            //    Console.WriteLine();
            //}

            //Console.ReadLine();

            int i, j, n = 0;
            int a = 1;
            int sign = 1;

            Console.WriteLine("Enter N: ");
            n = Convert.ToInt32(Console.ReadLine());

            for (i = 1; i <= n; i++)
            {
                for (j = 1; j <= i; j++)
                {
                    Console.Write(a * a * sign + " ");
                    a = a + 1;
                    sign = sign * (-1);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
