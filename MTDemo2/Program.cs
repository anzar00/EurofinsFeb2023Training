using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MTDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(M1);
            Thread t2 = new Thread(M2);
            Thread t2a = new Thread(() => { M2(100); });
            Thread t2b = new Thread(M5);
            Thread t3 = new Thread(M3);
            Thread t4 = new Thread(M4);

            Task tt1 = new Task(M1);
            tt1.Start();

            Task ttt1 = Task.Factory.StartNew(M1);
            Task tt2 = new Task(() => { M2(100); });
            Task<int> tt3 = new Task<int>(M3);
            tt3.Start();
            A
            B
            C
            int r = tt3.Result;
            Task<int> tt4 = new Task<int>(() => {return M4(50); });
            tt4.Start();
            int r2 = tt4.Result;
            Task<int> ttt4 = new Task<int>(() => M4(50) );
            ttt4.Start();
            int r3 = tt4.Result;

            Console.WriteLine(r2);
            Console.WriteLine(r3);
        }

        static void M1() { }

        static void M2(int i) { }

        static int M3() { return 1; }

        static int M4(int x) { return 0; }

        static void M5() { M2(100) ;}
    }
}
