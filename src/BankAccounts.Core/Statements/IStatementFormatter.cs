using BankAccounts.Core.Transactions;

namespace BankAccounts.Core.Statements;
//Форматирование - это отдельная ответственность.
//Можно добавить на будующеее JSON/CSV без правки счета (SRP)
public interface IStatementFormatter
{
    string Format(IEnumerable<Transaction> transactions);
}
