using StudentMarks.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMarks.ConsoleApp // UI
{
    internal class Program 
    {
        static void Main(string[] args)
        {
            // Take inputs

            string name;
            int maths;
            int physics;
            int chemistry;

            Console.WriteLine("Enter student name:");
            name = Console.ReadLine();
            Console.WriteLine("Enter marks scored in Maths : ");
            maths= int.Parse(Console.ReadLine());
            Console.WriteLine("Enter marks scored in Physics : ");
            physics= int.Parse(Console.ReadLine());
            Console.WriteLine("Enter marks scored in Chemistry : ");
            chemistry= int.Parse(Console.ReadLine());
            int total;
            total = Total.TotalMarks(maths, physics, chemistry);
            float average;
            average = Average.AverageMarks(total);

            // Display Average

            Console.WriteLine($"Average Marks Scored - {average}");

            // Display Total

            Console.WriteLine($"Total Marks scored - {total} ");

            // Display Class
            string result = PassClass.StudentResult(average);
            Console.WriteLine($"Result for student - {name} is {result}");
            Console.ReadKey();
        }
    }
}
