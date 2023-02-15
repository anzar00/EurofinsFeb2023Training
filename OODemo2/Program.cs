using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Shape s = new Shape();
            //s.Draw();
            //Console.WriteLine(s.CalculateArea(15, 2));
            //Rectangle r = new Rectangle();
            //r.Draw();
            //Console.WriteLine(r.CalculateArea(15,2));
            Triangle t = new Triangle();
            t.Draw();
            Console.WriteLine(t.CalculateArea(10, 10));

            //Base Class Reference variable can hold a derived type objects.

            Shape shape = new Triangle();
            shape.Draw();
            Console.WriteLine(shape.CalculateArea(10, 10));

        }
    }

    //abstract class Shape
    //{
    //    public abstract void Draw();
    //    //{
    //    //    Console.WriteLine("Drawing Shapre");
    //    //}

    //    public abstract double CalculateArea(double width, double height);
    //    //{
    //    //    Console.WriteLine("Calculating Shape Area");
    //    //    return width * height;
    //    //}
    //}

    interface IShape
    {
        void Draw();

        double CalculateArea(double width, double height);

    }

    //class Rectangle : Shape
    //{
    //    public override void Draw()
    //    {
    //        Console.WriteLine("Drawing Rectangle");
    //    }
    //    public override double CalculateArea(double width, double height)
    //    {
    //        Console.WriteLine("Calculating Rectangle Area");
    //        return width * height;
    //    }
    //}

    class Rectangle : IShape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing Rectangle");
        }
        public override double CalculateArea(double width, double height)
        {
            Console.WriteLine("Calculating Rectangle Area");
            return width * height;
        }
    }

    //class Triangle : Shape
    //{
    //    //Method Hiding - Compiler hides the inherited member. It suggests to use the new keyword if the hiding is intended
    //    public override double CalculateArea(double width, double height)
    //    {
    //        Console.WriteLine("Calculating Triangle Area");
    //        return .5 * width * height;
    //    }

    //    public override void Draw()
    //    {
    //        Console.WriteLine("Drawing a Triangle");
    //    }
    //}

    class Triangle : IShape
    {
        //Method Hiding - Compiler hides the inherited member. It suggests to use the new keyword if the hiding is intended
        public override double CalculateArea(double width, double height)
        {
            Console.WriteLine("Calculating Triangle Area");
            return .5 * width * height;
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing a Triangle");
        }
    }
}
