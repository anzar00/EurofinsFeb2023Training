namespace BankAppProblem.ConsoleApp
{
    public interface IAccountManager
    {

        // AccountManager should manage the accounts for opening, closing, withdraw, 
        // deposits and transfer

        int OpenAccount(string name, int pin, double balance);
        void CloseAccount(int accNo);
        void Withdraw(int accNo, int pin, double amount);
        void Deposit(int accNo, double amount);
        void Transfer(int fromAccNo, int toAccNo, double amount);
    }
}