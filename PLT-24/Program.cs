using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PLT_24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Write the pseudocodes to generate the following outputs. In all the following
            //cases, accept N: 

            //1
            //1 2
            //1 2 3
            //1 2 3 4
            //: 
            //N rows

            //int i, j = 0;
            //Console.WriteLine("Enter N (rows)");
            //int n = Convert.ToInt32(Console.ReadLine());

            //for (i = 1; i <= n; i++)
            //{
            //    for (j = 1; j <= i; j++)
            //    {
            //        Console.Write(j + " ");
            //    }
            //    Console.WriteLine();
            //}

            //1
            //2 2
            //3 3 3
            //4 4 4 4
            //: 
            //N rows

            //int i, j = 0;
            //Console.WriteLine("Enter N (rows)");
            //int n = Convert.ToInt32(Console.ReadLine());

            //for (i = 1; i <= n; i++)
            //{
            //    for (j = 1; j <= i; j++)
            //    {
            //        Console.Write(i + " ");
            //    }
            //    Console.WriteLine();
            //}

            //1
            //2 3
            //4 5 6
            //7 8 9 10
            //: 
            //N rows

            //int i, j = 0;
            //int k = 1;
            //Console.WriteLine("Enter N (rows)");
            //int n = Convert.ToInt32(Console.ReadLine());

            //for (i = 1; i <= n; i++)
            //{
            //    for (j = 1; j <= i; j++)
            //    {
            //        Console.Write(k + " ");
            //        k += 1;
            //    }
            //    Console.WriteLine();
            //}

            //1
            //1 2
            //3 5 8
            //: 
            //: 
            //N rows

            int i, j = 0;
            int k = 1;
            Console.WriteLine("Enter N (rows)");
            int n = Convert.ToInt32(Console.ReadLine());
            int a,next = 1;
            int b = 0;

            for (i = 1; i <= n; i++)
            {
                for (j = 1; j <= i; j++)
                {
                    Console.Write(next + " ");
                    a = b;
                    b = next;
                    next = a + b;
                }
                Console.WriteLine();
            }


        }
    }
}
