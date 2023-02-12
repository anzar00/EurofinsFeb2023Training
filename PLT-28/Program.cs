using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLT_28
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Write a pseudocode to store elements into a M * N matrix of integer. Display the 
            //matrix and its transpose.

            Console.WriteLine("Enter M: ");
            int m = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter N: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[,] matrix = new int[m, n];

            Console.WriteLine("Enter the elements of the matrix: ");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            Console.WriteLine("The matrix is: ");

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("The transpose of the matrix is: ");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(matrix[j, i] + " ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
