using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo2
{
    // Delegate Application for process management example
    internal class Program
    {
        static void Main(string[] args)
        {
            // Client 1
            //ProcessManager.ShowProcessList();
            //Use of delegate


            // Client 2
            //ProcessManager.ShowProcessList("c");

            // Client 3
            //ProcessManager.ShowProcessList(50*1024*1024);


            // Delegate Instance
            //FilterDelegate filterDelegate = new FilterDelegate(FilterByName);
            //// Subscription
            //filterDelegate += FilterByMemSize;

            //ProcessManager.ShowProcessList(filterDelegate);

            // Anonymous Delegate

            ProcessManager.ShowProcessList(delegate (Process p)
            {
                return p.WorkingSet64 >= 50*1024*1024;
            });

            // Lambdas
            // - Lambda Statements
            // - Lambda Expression

            ProcessManager.ShowProcessList(p => p.WorkingSet64 >= 50*1024*1024); // Lambda Expression 
            ProcessManager.ShowProcessList(p => true); // Lambda Expression 
            

        }
        public static bool NoFilter(Process p)
        {
            return true;
        }
        public static bool FilterByName(Process p)
        {
            return p.ProcessName.StartsWith("S");
        }

        public static bool FilterByMemSize(Process p)
        {
            return p.WorkingSet64 >= 50 * 1024 * 1024;
        }
    }

    public delegate bool FilterDelegate(Process p);
    class ProcessManager
    {
        //public static void ShowProcessList()
        //{
        //    foreach(Process p in Process.GetProcesses())
        //    {
        //        Console.WriteLine($"Process Name: {p.ProcessName}");
        //    }
        //}
        public static void ShowProcessList(FilterDelegate filterDelegate)
        {
            foreach (Process p in Process.GetProcesses())
            {
                if(filterDelegate(p))
                    Console.WriteLine($"Process Name: {p.ProcessName}");
            }
        }

        //public static void ShowProcessList(long size)
        //{
        //    foreach (Process p in Process.GetProcesses())
        //    {
        //        if (p.WorkingSet64>size)
        //            Console.WriteLine($"Process Name: {p.ProcessName} - Size: {p.WorkingSet64/1024/1024} MB");
        //    }
        //}
    }
}
