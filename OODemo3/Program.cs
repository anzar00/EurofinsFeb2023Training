using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OODemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyMathApp app = new MyMathApp();
            app.Calculator = new SimpleCalculator();
            app.Sum(23, 43, 45, 34, 34, 45, 5656);
        }
    }

    interface ICalculator
    {
        int Sum(params int[] numbers);
    }

    class SimpleCalculator : ICalculator // Borrowing the interface abstract
    {
        public int Sum(int[] numbers) // Only the abstract is borrowed from the interface, the implementation should be provided
        {
            int sum = 0;
            foreach (int i in numbers)
            {
                sum += i;
            }
            Console.WriteLine("Simple Calclator");
            return sum;
        }
    }
    class SuperCalculator : ICalculator //Borrows the abstraction as well as the implementation from SimpleCalculator
    {
        public int Sum(params int[] numbers) //Different implementation 
        {
            //SimpleCalculator sc = new SimpleCalculator(); //Borrows only the impleentation
            //return sc.Sum(numbers);

            // Go for HAS - A

            Console.WriteLine("Super Calculator");
            return numbers.Sum();
        }
    }
    class MyMathApp : ICalculator //Borrows the abstraction as well as the implementation from SimpleCalculator
    {
            //    public int FindSum(int[] numbers) //Different implementation 
            //    {
            //        SimpleCalculator sc = new SimpleCalculator(); //Borrows only the impleentation
            //        return sc.Sum(numbers);
            //    }
        public ICalculator Calculator { get; set; }
        public int Sum(params int[] numbers)
        {
            return Calculator.Sum(numbers);
        }
    }
    //}
}
