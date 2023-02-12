using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PLT_26
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //            Write a pseudocode to store N elements in an array of integer. Display the
            //elements.Accept a number to be searched. Display whether the number is found
            //or not in the array(LINEAR SEARCH). 

            Console.WriteLine("Enter N: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[n];

            Console.WriteLine("Enter the elements of the array: ");
            for (int i = 0; i < n; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("The elements of the array are: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine("\nEnter the number to be searched: ");
            int search = Convert.ToInt32(Console.ReadLine());

            int flag = 0;
            for (int i = 0; i < n; i++)
            {
                if (array[i] == search)
                {
                    flag = 1;
                    break;
                }
            }

            if (flag == 1)
            {
                Console.WriteLine("The number is found in the array.");
            }
            else
            {
                Console.WriteLine("The number is not found in the array.");
            }

            Console.ReadKey();
        }
    }
}
