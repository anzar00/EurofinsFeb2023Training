using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MTDemo5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BigData data= new BigData();
            //data.Fill();
            //data.Fill();
            Parallel.Invoke(data.Fill, data.Fill);
            Console.WriteLine(data.Count);
        }
    }

    public class BigData
    {
        // private Stack<int> stack = new Stack<int>();
        private ConcurrentStack<int > stack = new ConcurrentStack<int>();
        // [MethodImpl(MethodImplOptions.Synchronized)] //Use if the entire methos is a critical section 
        public void Fill()
        {
          //  lock (stack) //Use if only a part of the method is a critical section
            {
                // lockk exapml
                //Fill a million numbers
                for (int i = 0; i < 1000000; i++)
                {
                   // Monitor.Enter(this);
                        stack.Push(i);
                   // Monitor.Exit(this);
                }
            }
        }

        public long Count
        {
            get { return stack.Count; }
        }
    }

}
