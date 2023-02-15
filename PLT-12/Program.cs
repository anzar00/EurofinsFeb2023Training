using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLT_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Write as many pseudocodes to generate the following series. In all the following cases, 
            //accept N: 

            //4, 16, 36, 64, … N

            //int i = 2;
            //int n = 0;
            //Console.WriteLine("Printing - 4, 16, 36, 64, … N");
            //Console.WriteLine("Enter  N");
            //n = Convert.ToInt32(Console.ReadLine());

            //while ((i*i) <= n)
            //{
            //    Console.Write(i*i + " ");
            //    i+=2;
            //}

            //1, -2, 3, -4, 5, -6, … N

            //Console.WriteLine("Printing - 1, -2, 3, -4, 5, -6, … N");
            //int i = 1;
            //int n = 0;
            //Console.WriteLine("Enter  N");
            //n = Convert.ToInt32(Console.ReadLine());

            //while(i <= n)
            //{
            //    if (i % 2 == 0)
            //    {
            //        Console.Write(-i + " ");
            //    }
            //    else
            //    {
            //        Console.Write(i + " ");
            //    }
            //    i++;
            //}

            //int i = 1;
            //int n = 0;
            //int sign = 1;

            //Console.WriteLine("Enter  N");
            //n = Convert.ToInt32(Console.ReadLine());

            //while (i <= n)
            //{
            //    Console.Write(sign * i + " ");
            //    sign = -sign;
            //    i++;
            //}

            //1, 4, 27, 256, 3125, … N

            //int i = 1;
            //int n = 0;

            //Console.WriteLine("Printing - 1, 4, 27, 256, 3125, … N");
            //Console.WriteLine("Enter N");
            //n = Convert.ToInt32(Console.ReadLine());

            //while((Math.Pow(i,i)) <= n)
            //{
            //    Console.Write((Math.Pow(i,i)) + " ");
            //    i++;
            //}

            //1, 4, 7, 12, 23, 42, 77, … N
            //int i = 1;
            //int j = 4;
            //int k = 7;

            //int next = 0;
            //int n = 0;

            //Console.WriteLine("Printing - 1, 4, 7, 12, 23, 42, 77, … N");
            //Console.WriteLine("Enter N");
            //n = Convert.ToInt32(Console.ReadLine());

            //if (n >= 7)
            //{
            //    Console.Write(i + " " + j + " " + k + " ");
            //}
            //else if (n >= 4)
            //{
            //    Console.Write(i + " " + j + " ");
            //}
            //else if (n >= 1)
            //{
            //    Console.Write(i + " ");
            //}
            //next = i+j+k;

            //while (next<=n)
            //{
            //    {
            //        Console.Write(next + " ");
            //        i = j;
            //        j = k;
            //        k = next;
            //        next = i + j + k;
            //    }
            //}


            //1, 4, 9, 25, 36, 49, 81, 100, … N

            //int i = 1;
            //int n = 0;

            //Console.WriteLine("Printing 1, 4, 9, 25, 36, 49, 81, 100, … N");
            //Console.WriteLine("Enter N");

            //n = Convert.ToInt32(Console.ReadLine());

            //while((i * i) <= n)
            //{
            //    if (i%4 != 0)
            //        Console.Write(i*i + " ");
            //    i++;
            //}

            //1, 5, 13, 29, 49, 77, … N

            int i = 1;
            int j = 4;
            
            int n = 0;

            Console.WriteLine("Printing 1, 5, 13, 29, 49, 77, … N");
            Console.WriteLine("Enter N");
            n = Convert.ToInt32(Console.ReadLine());

            while (i <= n)
            {
                Console.Write(i + " ");
                i += j;
                j += 4;

                if(j%12 == 0)
                {
                    j+=4;
                }
            }

            Console.ReadKey();

        }
    }
}
