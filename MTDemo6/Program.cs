using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MTDemo6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            M1();
        }

        static void M1()
        {
            int pcount = Environment.ProcessorCount;
            ParallelOptions opts= new ParallelOptions();
            opts.MaxDegreeOfParallelism = pcount/2; // Giving only half the cores to the thread.

            HashSet<int> set = new HashSet<int>();
            Parallel.For(1, 100, opts, i =>
            {
                lock (set)
                {
                    set.Add(Thread.CurrentThread.ManagedThreadId);
                }
                // code block
            });
            Console.WriteLine(set.Count);
        }
    }
}
