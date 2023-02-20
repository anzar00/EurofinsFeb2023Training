using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccess
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    interface IDepositable
    {
        bool Deposit(double amount);
    }

    abstract class Account : IDepositable
    {
        public string AccountNumber { get; set; }
        public int Balance { get; set; }
        public int IntrestRate { get; set; }
        public int MonthsHeld { get; set; }
        public IIntersetCalculator IntersetCalculator { get; set; }
        public Customer customer { get; set; }
        public bool Deposit(double amount)
        {
            return false;
        }
        public double CalculateIntrest()
        {
            return IntersetCalculator.CalculateIntrest(this);
        }
    }

    class Bank
    {
        public List<Account> accounts { get; set; }
    }

    interface IWithdrawable
    {
        bool Withdraw(double amount);
    }

    class Savings : Account
    {

    }
    class Loan : Account 
    { 
    
    }
    class Mortage : Account 
    {
    
    }
    abstract class Customer
    {

    }
    class Individual : Customer 
    {
    
    }
    class Company : Customer 
    {
    
    }
    interface IIntersetCalculator
    {
        double CalculateIntrest(Account account);

    }

    class LoanIndividualIntrestCalculator : IIntersetCalculator
    {
        public double CalculateIntrest(Account account)
        {
            return 0;
        }
    }
    class LoanCompanyIntrestCalculator : IIntersetCalculator
    {
        public double CalculateIntrest(Account account)
        {
            return 0;
        }
    }
    class MortageIndividualIntrestCalculator : IIntersetCalculator
    {
        public double CalculateIntrest(Account account)
        {
            return 0;
        }
    }
    class MortageCompanyIntrestCalculator : IIntersetCalculator
    {
        public double CalculateIntrest(Account account)
        {
            return 0;
        }
    }
    class SavingsIntrestCalculator : IIntersetCalculator
    {
        public double CalculateIntrest(Account account)
        {
            return 0;
        }
    }
}
