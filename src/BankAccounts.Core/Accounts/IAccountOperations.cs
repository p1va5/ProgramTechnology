namespace BankAccounts.Core.Accounts;

public interface IAccountOperations
{
    decimal Balance {  get; }
    void Deposit(decimal amount, DateTime date, string note);
    void Withdrawal(decimal amount, DateTime date, string note);
}
