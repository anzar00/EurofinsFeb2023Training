using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //// Delegate Instance 
            //NotifyDelegate notifyDelegate = new NotifyDelegate(Notification.SendEmail);
            //notifyDelegate += Notification.SendSMS;
            
            Account acc1 = new Account();
            //acc1.notify += Notification.SendSMS;
            //acc1.Subscribe(Notification.SendSMS);
            acc1.notify += Notification.SendSMS;
            //acc1.notify += Notification.SendEmail;
            //acc1.Subscribe(Notification.SendEmail);
            //acc1.Deposit(5000, notifyDelegate);
            acc1.notify += Notification.SendEmail;
            acc1.Deposit(5000);
            Console.WriteLine($"Account Balance - {acc1.Balance}");
            //acc1.Withdraw(1000, notifyDelegate);
            acc1.Withdraw(3000);
            Console.WriteLine($"Account Balance - {acc1.Balance}");
             
        }
    }

    //Delegate for notifications 

    public delegate void NotifyDelegate(string msg);
    public class Account
    {
        public int Balance { get; private set; }
        //private NotifyDelegate notify { get; set; }
        public event NotifyDelegate notify;

        //public void Subscribe(NotifyDelegate alert)
        //{
        //    notify += alert;
        //}

        //public void Unsubscribe(NotifyDelegate alert)
        //{
        //    notify -= alert;
        //}

        //        public void Deposit(int amount, NotifyDelegate notifyDelegate)
        public void Deposit(int amount)
        {
            Balance += amount;
            string msg = $"Your acccount has been credited by {amount}.";
            //notifyDelegate(msg);
            if(notify != null)
                notify(msg);
        }

        //        public void Withdraw(int amount, NotifyDelegate notifyDelegate)
        public void Withdraw(int amount)
        {
            Balance -= amount;
            string msg = $"Your acccount has been debited by {amount}.";
            //notifyDelegate(msg);
            if(notify!= null)
                notify(msg);
        }
    }

    public class Notification
    {
        public static void SendEmail(string msg)
        {
            Console.WriteLine($"Mail: {msg}");
        }

        public static void SendSMS(string msg)
        {
            Console.WriteLine($"Text: {msg}");
        }

    }
}
