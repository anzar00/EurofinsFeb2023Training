using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using System.Security.AccessControl;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace OutstandingPersons
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person[] persons = new Person[5];


            Student s1 = new Student();
            s1.Name = "John";
            s1.Percentage = 90;
            persons[0] = s1;

            Student s2 = new Student();
            s2.Name = "Mary";
            s2.Percentage = 80;
            persons[1] = s2;

            Student s3 = new Student();
            s3.Name = "Peter";
            s3.Percentage = 95;
            persons[2] = s3;

            Professor p1 = new Professor();
            p1.Name = "Sam";
            p1.BooksPublished = 5;
            persons[3] = p1;

            Professor p2 = new Professor();
            p2.Name = "Raj";
            p2.BooksPublished = 3;
            persons[4] = p2;

            foreach (Person p in persons)
            {
                if (p.IsOutstanding())
                {
                    if (p is Student)
                    {
                        Student s = (Student)p;
                        s.Display();
                    }
                    else
                    {
                        Professor pr = (Professor)p;
                        pr.Print();
                    }
                }
            }

        }
    }

                   

    class Person
    {
        public string Name { get; set; }
        public virtual bool IsOutstanding()
        {
            return false;
        }

        
    }
    
    class Professor : Person
    {
        public int BooksPublished { get; set; }
        public override bool IsOutstanding()
        {
            if (BooksPublished > 4)
                return true;
            return false;
        }

        public void Print()
        {
            Console.WriteLine($"Name: {this.Name}, Books Published: {BooksPublished}");
        }

    }

    class Student : Person
    {
        public double Percentage { get; set; }

        public override bool IsOutstanding()
        {
            if (Percentage>85)
                return true;
            return false;
        }

        public void Display()
        {
            Console.WriteLine($"Name: {this.Name}, Percentage: {Percentage}");
        }

    }

}
