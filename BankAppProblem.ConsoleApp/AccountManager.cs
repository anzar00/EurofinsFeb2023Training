using System.Collections.Generic;

namespace BankAppProblem.ConsoleApp
{
    //AccountManager should manage the accounts for opening, closing, withdraw, 
    //deposits and transfer

    class AccountManager : IAccountManager
    {
        // AccountManager should manage the accounts for opening, closing, withdraw, 
        // deposits and transfer

        //private List<Account> accounts;

        //public AccountManager()
        //{
        //    accounts = new List<Account>();
        //}

        //public void AddAccount(Account account)
        //{
        //    accounts.Add(account);
        //}

        private List<Account> accounts;

        public AccountManager()
        {
            accounts = new List<Account>();
        }
        public int OpenAccount(string name, int pin, double balance)
        {
            
            return 0;
        }
        public void CloseAccount(int accNo)
        {

        }
        public void Withdraw(int accNo, int pin, double amount)
        {

        }
        public void Deposit(int accNo, double amount)
        {

        }
        public void Transfer(int fromAccNo, int toAccNo, double amount)
        {

        }
    }

}
