using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdasDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //Find sum of all even numbers
            int evenSum = numbers.FindAll(n => n % 2 == 0).Sum();
            Console.WriteLine(evenSum);
            int oddSum = numbers.Where(n => n % 2 != 0).Sum();
            Console.WriteLine(oddSum);
        }
    }
}
