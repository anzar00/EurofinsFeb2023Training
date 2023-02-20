using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Accept 2 int, find the sum and display.

            int num1, num2, sum;
            
            while(true)
            {
                try //A try block can have multiple catch blocks.
                {
                    Console.WriteLine("Enter the first number: ");
                    num1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the second number: ");
                    num2 = Convert.ToInt32(Console.ReadLine());

                    sum = num1 + num2;

                    Console.WriteLine($"The sum of {num1} and {num2} is: {sum}");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message + "\nEnter only numbers.");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ex.Message + "\nEnter small numbers.");
                }
                catch (Exception ex) //Catch All
                {
                    Console.WriteLine("Unknown Error. Try Again.\n" + ex.Message);
                }
            }
        }
    }
}
