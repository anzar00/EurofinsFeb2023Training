using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PLT_19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Write the pseudocodes to generate the following series. In all the following cases, 
            // accept N: 

            // 1, -2, 6, -15, 31, -56, … N

            //Console.WriteLine("Printing\n1 -2 6 -15 31 -56 ... N");
            //int n = 0;
            //Console.WriteLine("Enter N (terms):");
            //n = Convert.ToInt32(Console.ReadLine());

            //int a = 1;
            //int sign = 1;

            //for(int i =1; i <= n; i++)
            //{
            //    Console.Write(a*sign + " ");
            //    a += i*i;
            //    sign = -sign;
            //}

            // 1, 1, 2, 3, 5, 8, 13, … N

            //Console.WriteLine("Printing\n1 1 2 3 5 8 13 ... N");
            //int n = 0;
            //Console.WriteLine("Enter N (terms)");

            //n = Convert.ToInt32(Console.ReadLine());

            //int i = 0;
            //int a = 1;
            //int b = 0;
            //int next = 1;

            //for(i=1; i<=n; i++)
            //{
            //    Console.Write(next + " ");
            //    a = b;
            //    b =next;
            //    next = a+b;
            //}

            // 1, -2, 4, -6, 7,-10, 10,-14… N

            //int a = 1;
            //int b = -2;
            //Console.WriteLine("Enter N (terms)");
            //int n = Convert.ToInt32(Console.ReadLine());

            //for(int i = 1; i <= n; i++)
            //{
            //    Console.Write(a+" "+b+" ");
            //    a +=3;
            //    b -= 4;
            //}


            // 1, 5, 8, 14, 27, 49, … N

            int a = 1;
            int b = 5;
            int c = 8;
            int next = 14;

            Console.WriteLine("Enter N(terms)");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write(a +" "+b+" "+c+" ");

            for(int i=1; i<=n-3; i++)
            {
                Console.Write(next + " ");
                a =b;
                b = c;
                c = next;
                next = a + b +c;
            }

            Console.ReadKey();
        }
    }
}
