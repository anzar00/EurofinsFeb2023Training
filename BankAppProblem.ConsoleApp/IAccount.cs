using System;

namespace BankAppProblem.ConsoleApp
{
    //An Account has accno, name, balance, pin number, isActive openingDate and
    //closingDate properties

    public interface IAccount
    {
        int AccNo { get; set; }
        string Name { get; set; }
        double Balance { get; set; }
        int Pin { get; set; }
        bool IsActive { get; set; }
        DateTime OpeningDate { get; set; }
        DateTime ClosingDate { get; set; }

        void OpenAccount(int pin, double balance);
        void CloseAccount();
        void Withdraw(int pin, double amount);
        void Deposit(double amount);
        void Transfer(Account toAccount, double amount);
    }

}
