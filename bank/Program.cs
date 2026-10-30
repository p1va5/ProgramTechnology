using BankAccounts.Core.Factories;
using BankAccounts.Core.Time;
using BankAccounts.Core.AccountNumbers;
using BankAccounts.Core.Statements;

namespace BankAccounts.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var clock = new SystemClock();
            var factory = new AccountFactory(clock, new SequentialAccountNumbersGenerator());
            var formatter = new TextStatementFormatter();
            var savings = factory.CreateInterestEarning("Yana", 10000m);
            savings.Deposit(100m, clock.Now, "asda");
            System.Console.WriteLine(formatter.Format(savings.Transactions));
        }
    }
}
