using System;

namespace BankAppProblem.ConsoleApp
{
    public class Account : IAccount
    {
        public int AccNo { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public int Pin { get; set; }
        public bool IsActive { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime ClosingDate { get; set; }

        public Account(int accNo, string name, double balance, int pin, bool isActive, DateTime openingDate, DateTime closingDate)
        {
            AccNo = accNo;
            Name = name;
            Balance = balance;
            Pin = pin;
            IsActive = isActive;
            OpeningDate = openingDate;
            ClosingDate = closingDate;
        }

        public void OpenAccount(int pin, double balance)
        {
            if (IsActive == true)
            {
                throw new Exception("Account is already open");
            }

            if (ClosingDate != null)
            {
                throw new Exception("Account is closed");
            }
            else
            {
                IsActive = true;
                OpeningDate = DateTime.Now;
                Balance = balance;
                Pin = pin;
            }
        }

        public void CloseAccount()
        {
            if (IsActive == false)
            {
                throw new Exception("Account is already closed");
            }

            if (ClosingDate != null)
            {
                throw new Exception("Account is already closed");
            }

            if (Balance > 0)
            {
                throw new Exception("Account has a balance and can not be closed");
            }
            else
            {
                IsActive = false;
                ClosingDate = DateTime.Now;
            }
        }

        public void Withdraw(int pin, double amount)
        {
            if (IsActive == false)
            {
                throw new Exception("Account is closed");
            }

            if (Pin != pin)
            {
                throw new Exception("Pin is incorrect");
            }

            if (Balance < amount)
            {
                throw new Exception("Insufficient funds");
            }
            else
            {
                Balance -= amount;
            }
        }

        public void Deposit(double amount)
        {
            if (IsActive == false)
            {
                throw new Exception("Account is closed");
            }
            else
            {
                Balance += amount;
            }
        }

        public void Transfer(Account toAccount, double amount)
        {
            if (IsActive == false)
            {
                throw new Exception("Sender account is closed");
            }

            if (toAccount.IsActive == false)
            {
                throw new Exception("Receiver account is closed");
            }

            if (Balance < amount)
            {
                throw new Exception("Insufficient funds");
            }
            else
            {
                Balance -= amount;
                toAccount.Balance += amount;
            }
        }
    }

}
