using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageEnhancementsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LINQ to Objects
            List<int> numbers = new List<int> { 1,2,3,4,5,6,7,8,9};
            //Extract all even numbers in a separate list
            //Traditional Method
            List<int> evenNumbers = new List<int>();
            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                {
                    evenNumbers.Add(number);
                }
            }
            //Display List of even numbers
            foreach (var evenNumber in evenNumbers)
            {
                Console.WriteLine(evenNumber);
            }
            //LINQ Expression
            var evenNumbers1 = from n in numbers
                               where n % 2 == 0
                               orderby n descending
                               select n;
            //LINQ Extension
            var evenNumbers2 = numbers.Where(n => n % 2 == 0).OrderByDescending(n => n);

            //Display List of even numbers
            foreach (var evenNumber in evenNumbers1)
            {
                Console.WriteLine(evenNumber);
            }

            //Display List of even numbers
            foreach (var evenNumber in evenNumbers2)
            {
                Console.WriteLine(evenNumber);
            }
        }
    }
}
