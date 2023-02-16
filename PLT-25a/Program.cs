using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PLT_25
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
            //int i, j, n = 0;
            //int a = 1;
            //int sign = 1;
            //Console.Write("Given pattern:\n" +
            //    "1\n" +
            //    "-4 9\n" +
            //    "-16 25 -36 \n");
            //Console.WriteLine("Enter N: ");
            //n = Convert.ToInt32(Console.ReadLine());

            //for (i = 1; i <= n; i++)
            //{
            //    for (j = 1; j <= i; j++)
            //    {
            //        Console.Write(a * a * sign + " ");
            //        a = a + 1;
            //        sign = sign * (-1);
            //    }
            //    Console.WriteLine();
            //}

            //1
            //1 2
            //6 24 120
            //: 
            //: 
            //N rows

            //int i, j;
            //int a = 1;
            //int b = 0;
            //Console.Write("Given pattern:\n" +
            //    "1\n" +
            //    "1 2\n" +
            //    "6 24 120 \n");

            //Console.WriteLine("Enter N: ");
            //int n = Convert.ToInt32(Console.ReadLine());

            //for (i = 1; i <= n; i++)
            //{
            //    for (j = 1; j <= i; j++)
            //    {
            //        Console.Write(a + " ");
            //        b = b + 1;
            //        a = a * b;
            //    }
            //    Console.WriteLine();
            //}

            //   *
            //  ** 
            // ***
            //****
            //: 
            //N rows

            //int i, j = 0;
            //Console.Write("Given pattern:\n" +
            //    "      *\n" +
            //    "    * *\n" +
            //    "  * * *\n" +
            //    "* * * *\n");

            //Console.WriteLine("Enter N: ");
            //int n = Convert.ToInt32(Console.ReadLine());

            //for (i = 1; i <= n; i++)
            //{
            //    for (j = 1; j <= n-i; j++)
            //    {
            //        Console.Write("  ");
            //    }

            //    for (j = 1; j <= i; j++)
            //    {
            //        Console.Write(" *");
            //    }
            //    Console.WriteLine();
            //}

            //   *
            //  ***
            // *****
            //*******
            //: 
            //N rows

            int i, j = 0;
            Console.Write("Given pattern:\n" +
                "   *\n" +
                "  * * *\n" +
                " * * * * *\n" +
                "* * * * * * *\n");

            Console.WriteLine("Enter N: ");
            int n = Convert.ToInt32(Console.ReadLine());

            for (i = 1; i <= n; i++)
            {
                for (j = 1; j <= n-i; j++)
                {
                    Console.Write("  ");
                }

                for (j = 1; j <= 2*i-1; j++)
                {
                    Console.Write(" *");
                }
                Console.WriteLine();
            }


            Console.ReadKey();
        }
    }
}
