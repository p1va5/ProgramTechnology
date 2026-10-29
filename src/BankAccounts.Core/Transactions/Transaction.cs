namespace BankAccounts.Core.Transactions;
//Простой(DTO)
public sealed record Transaction(decimal Amount, DateTime Date, string Note);