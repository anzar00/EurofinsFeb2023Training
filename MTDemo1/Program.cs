using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;// TPL
using System.Threading;// Classic Thread
using System.Diagnostics;
using System.Runtime.ExceptionServices;

namespace MTDemo1
{
    internal class Program
    {
        static int Main(string[] args)
        {
            //Console.WriteLine("Running Sequentially ...");
            //Stopwatch stopwatch= Stopwatch.StartNew();
            //M1();
            //M2();
            //Console.WriteLine(stopwatch.ElapsedMilliseconds);
            //// Classic Thread Implementation
            //Console.WriteLine("Using Classic Thread");
            //stopwatch = Stopwatch.StartNew();

            //ThreadStart ts1 = new ThreadStart(M1);
            //Thread t1 = new Thread(ts1);
            //t1.Start();

            //Thread t2 = new Thread(M2);
            //t2.Start();
            //t1.Join();
            //t2.Join();
            //Console.WriteLine(stopwatch.ElapsedMilliseconds);

            //Console.WriteLine("Using TPL-Task");
            //stopwatch= Stopwatch.StartNew();
            //Task task1 = new Task(M1);
            //task1.Start();
            //Task task2 = new Task(M2);
            //task2.Start();
            //task1.Wait();
            //task2.Wait();
            //Console.WriteLine(stopwatch.ElapsedMilliseconds);

            //Console.WriteLine("Using TPL-Parallel"); 
            //stopwatch= Stopwatch.StartNew();
            //Parallel.Invoke(M1, M2);
            //Console.WriteLine(stopwatch.ElapsedMilliseconds);

            //Console.WriteLine("Using TPL-Parallel-For");
            //stopwatch= Stopwatch.StartNew();
            //Parallel.Invoke(M11, M22);
            //Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.WriteLine(Environment.ProcessorCount);
            M3();
            return 0;

        }
        static void M1()
        {
            Console.WriteLine($"M1: {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 1; i<=5; i++)
            {
                Thread.Sleep(1000);
            }
            //for(int i = 0; i<10; i++)
            //{
            //    Console.WriteLine($"M1 -  ");
            //}
        }
        static void M2()
        {
            Console.WriteLine($"M2: {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 1; i<=5; i++)
            {
                Thread.Sleep(1000);
            }
        }

        static void M11()
        {
           Console.WriteLine($"M11: {Thread.CurrentThread.ManagedThreadId}");
            Parallel.For(1, 11,i =>
            {
                Thread.Sleep(500);
            });
        }

        static void M22()
        {
            Console.WriteLine($"M22: {Thread.CurrentThread.ManagedThreadId}");
            Parallel.For(1, 11, delegate (int i)
            {
                Thread.Sleep(500);
            });
        }

        static void M3()
        {
            // Initialize the HashMap to keep track of the number of threads created
            var threadCountMap = new Dictionary<int, int>();

            Parallel.For(1, 101, delegate (int i)
            {
                int currentThreadId = Thread.CurrentThread.ManagedThreadId;
                Console.WriteLine($"Thread ID: {currentThreadId}");
                Thread.Sleep(500);

                // Update the count of threads created by this thread ID in the HashMap
                lock (threadCountMap)
                {
                    if (threadCountMap.ContainsKey(currentThreadId))
                    {
                        threadCountMap[currentThreadId] += 1;
                    }
                    else
                    {
                        threadCountMap[currentThreadId] = 1;
                    }
                }
            });

            // Output the count of threads created by each thread ID in the HashMap
            foreach (var kvp in threadCountMap)
            {
                Console.WriteLine($"Thread ID {kvp.Key}: {kvp.Value} threads created");
            }
        }

    }
}
