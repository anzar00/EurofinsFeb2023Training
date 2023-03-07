using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //Extract all even numbers in a separate list
            var evenNumbers = (from n in numbers
                              where IsEven(n)
                              select n).ToList();
            //LINQ always returns IEnnumerables 
            numbers.Add(10);

            //Display List of even numbers to potray deferred execution of the query
            foreach (var evenNumber in evenNumbers)
            {
                Console.WriteLine(evenNumber);
            }
        }

        public static bool IsEven(int number)
        {
            Console.WriteLine("Is even");
            return number % 2 == 0;
        }

        public static List<int> GetEvens(List<int> numbers)
        {
            var evens = (from n in numbers
                        where n % 2 == 0
                        select n).ToList();
            return evens;
        }
    }
}
