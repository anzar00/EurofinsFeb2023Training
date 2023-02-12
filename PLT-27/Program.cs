using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PLT_27
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Write a pseudocode to store N elements in an array of integer. Display the
            //elements.Sort the elements.Accept a number to be searched. Display whether
            //the number is found or not in the array using BINARY SEARCH.

            //Store n elements in an array
            Console.WriteLine("Enter N: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[n];

            Console.WriteLine("Enter the elements of the array: ");
            for (int i = 0; i < n; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }

            //Display the elements

            Console.WriteLine("The elements of the array are: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(array[i] + " ");
            }

            //Sort the elements

            Array.Sort(array);

            //Accept a number to be searched

            Console.WriteLine("\nEnter the number to be searched: ");
            int search = Convert.ToInt32(Console.ReadLine());

            //Display whether the number is found or not in the array using BINARY SEARCH

            int first = 0;
            int last = n - 1;
            int middle = (first + last) / 2;

            while (first <= last)
            {
                if (array[middle] < search)
                {
                    first = middle + 1;
                }
                else if (array[middle] == search)
                {
                    Console.WriteLine($"{search} found at location {middle+1}.");
                    break;
                }
                else
                {
                    last = middle - 1;
                }
                middle = (first + last) / 2;
            }
            if (first > last)
            {
                Console.WriteLine("{0} is not found.", search);
            }

            Console.ReadKey();
        }
    }
}