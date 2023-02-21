using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo1
{
    public delegate void GreetingDelegate(string text); // Delegate Declaration
    internal class Program
    {
        static void Main(string[] args)
        {
            //Direct Method Invocation
            Greeting("Hello"); 
            
            // Create a delegate instance
            GreetingDelegate greetingDelegate = new GreetingDelegate(Greeting);

            // Subscription 
            Program p = new Program();
            greetingDelegate += p.Hi;

            // Unsubscription

            greetingDelegate -= Greeting;

            // Invoke the delegate
            greetingDelegate("Hello World, delegate here.");

            greetingDelegate.Invoke("Hello World, delegate here using .Invoke");
        }

        static void Greeting(string text)
        {
            Console.WriteLine($"Greeting: {text}");
        }

        public void Hi(string msg)
        {
            Console.WriteLine($"Hi: {msg}");
        }
    }
}
