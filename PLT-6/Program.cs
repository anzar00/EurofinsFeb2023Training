using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLT_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Write a pseudocode to find the largest and second largest of 3 numbers

            Console.WriteLine("Enter the first number :");
            int firstNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the second number :");
            int secondNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the third number :");
            int thirdNumber = Convert.ToInt32(Console.ReadLine());

            int largest = firstNumber;
            int secondLargest = secondNumber;

            if (secondNumber > largest)
            {
                largest = secondNumber;
                secondLargest = firstNumber;
            }

            if (thirdNumber > largest)
            {
                secondLargest = largest;
                largest = thirdNumber;
            }
            else if (thirdNumber > secondLargest)
            {
                secondLargest = thirdNumber;
            }

            Console.WriteLine($"Largest number is - {largest}");

            Console.WriteLine($"Second largest number is - {secondLargest}");

            Console.ReadLine();
        }
    }
}
