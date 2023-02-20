using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsDemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            numbers.Add(1);
            numbers.Add(2); 
            numbers.Add(3); 
            numbers.Add(4); 
            numbers.Add(5);


            Console.WriteLine($"Capacity: {numbers.Capacity}");
            Console.WriteLine($"Count: { numbers.Count}");

            int max = numbers.Max();
            int min = numbers.Min();
            double avg = numbers.Average();
            int sum = numbers.Sum();

            //Staks

            Stack<int> stack = new Stack<int>();

            //add

            stack.Push(10);
            stack.Push(20);

            //read

            int a = stack.Pop();
            int b = stack.Peek();

            // Queue

            Queue<int> q = new Queue<int>();

            //add
            q.Enqueue(10);
            q.Enqueue(20);

            int x = q.Dequeue();
            x = q.Peek();

            //Hash Set

            HashSet<int> set = new HashSet<int>();
            set.Add(1);
            set.Add(2);
            set.Add(2);
            Console.WriteLine(set.Count);

        }
    }
}
