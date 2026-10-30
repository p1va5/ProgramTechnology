using BankAccounts.Core.AccountNumbers;
using BankAccounts.Core.MonthEnd;
using BankAccounts.Core.Time;
using BankAccounts.Core.Transactions;
using BankAccounts.Core.Withdrawals;

namespace BankAccounts.Core.Accounts;
//Тонкий класс - ядро хранит транзакции, применяя политики и правила
public class BankAccount : IAccountOperations, IAccountStatement
{
    private readonly List<Transaction> _transactions = new();
    private readonly List<IMonthEndRule> _monthEndRule;

    private readonly IClock _clock;
    private readonly IWithdrawalPolicy _withdrawalPolicy;
    public string Number { get; }
    public string Owner { get; }
    public decimal MinimumBlance { get; }
    public IReadOnlyList<Transaction> Transactions => _transactions;
    public decimal Balance => _transactions.Sum(t => t.Amount);

    public BankAccount(IClock clock, IAccountNumbersGenerator numbersGenerator, string owner, decimal initialBalance, decimal minimumBlance, IWithdrawalPolicy withdrawalPolicy, IEnumerable<IMonthEndRule>? monthEndRules = null)
    {
        _monthEndRule = monthEndRules?.ToList() ?? null;
        _clock = clock;
        _withdrawalPolicy = withdrawalPolicy;
        Number = numbersGenerator.Next();
        Owner = owner;
        MinimumBlance = minimumBlance;
        if (initialBalance > 0) Deposit(initialBalance, _clock.Now, "initialBalance");

    }
    public void Deposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
        }
        var deposite = new Transaction(amount, date, note);
        _transactions.Add(deposite);
    }
    public void Withdrawal(decimal amount, DateTime date, string note)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
        //применяем политику снятия: получаем решение, а не исключение
        var decision = _withdrawalPolicy.Evaluate(Balance, amount, MinimumBlance);
        if (!decision.IsAllowed) throw new InvalidOperationException(decision.RejectionReason);
        _transactions.Add(new Transaction(-amount, date, note));
        if(decision.Fee>0)_transactions.Add(new Transaction(amount, date, note));
    }
    public virtual void PerforMonthEndTransactions()
    {
        var asOf = _clock.Now;
        foreach (var rule in _monthEndRule) rule.Apply(this, asOf);
    }
}
