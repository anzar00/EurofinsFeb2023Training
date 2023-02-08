using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLT_29
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Write a pseudocode to store elements into a N * N matrix of integer. Display 
            //whether it is an identity matrix or not.

            Console.WriteLine("Enter N: ");

            int n = Convert.ToInt32(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine($"Enter element - {i},{j} :");
                    matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            bool isIdentity = true;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        if (matrix[i, j] != 1)
                        {
                            isIdentity = false;
                            break;
                        }
                    }
                    else
                    {
                        if (matrix[i, j] != 0)
                        {
                            isIdentity = false;
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(isIdentity ? "Identity" : "Not Identity");

            Console.ReadLine();
        }
    }
}
