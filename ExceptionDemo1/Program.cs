using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.Remoting.Services;
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

                    sum = Calculator.Sum(num1, num2);

                    Console.WriteLine($"The sum of {num1} and {num2} is: {sum}");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message + "\nEnter only numbers.");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ex.Message + "\nEnter small numbers.");
                }/// <param name="a">first int</param>ossoov
                catch (NegativeNumberException ex)
                {
                    Console.WriteLine("Enter only posi");
                }
                catch (Exception ex) //Catch All
                {
                    Console.WriteLine("Unknown Error. Try Again.\n" + ex.Message);
                    if(ex.InnerException.Message != null)
                        Console.WriteLine(ex.InnerException.Message);
                }
                finally
                {
                    // always executes
                }
            }
        }
    }
    
    public class Calculator //BLL
    {
        public static int Sum(int a, int b)
        {
            // non-zero, even numbers.
            // To achieve this, the developer can throw a Custom exception.
            try
            {
                InputValidator.Validate(a, b);
            }
            catch (Exception ex)
            {
                LogManager.LoadConfiguration("nlog.config");
                var log = LogManager.GetCurrentClassLogger();
                log.Error(ex.Message);
                throw ex;
            }
            int sum = a+b;
            // save
            try
            {
                CalculatorRepository.Save($"{a} + {b} = {sum}");
            }
            catch(Exception ex)
            {
                UnableToSaveException exp = new UnableToSaveException("Unable to save the calculator output", ex);
            }
            return a+b;
        }
    }

    public class NegativeNumberException : ApplicationException
    {
        public NegativeNumberException()
        {

        }

        public NegativeNumberException(string msg): base(msg)
        {

        }

       
    }

    public class UnableToSaveException : ApplicationException
    {
        //public UnableToSaveException()
        //{
                
        //}

        //public UnableToSaveException(string msg) : base(msg)
        //{

        //}

        public UnableToSaveException(string msg = null, Exception innerException = null) : base(msg, innerException)
        {

        }
    }

    public class InputValidator
    {
        /// <summary>
        /// Calculator will be used for finding mathematical calculations.
        /// </summary>
        /// <param name="num1">first int</param>
        /// <param name="num2">second int</param>
        /// <returns>Sum of two Ints</returns>
        /// <exception cref="NegativeNumberException"></exception>
        public static bool Validate(int a, int b)
        {
            // Input should only positive,
            if (a< 0 || b<0)
            {
                NegativeNumberException exception = new NegativeNumberException("Enter only positive numbers.");
                throw exception;
            }
            return true;
        }

    }
    
    public class CalculatorRepository // DAL
    {
        public static void Save(string input)
        {
            File.WriteAllText("calculator.txt", input);
        }
    }
}
