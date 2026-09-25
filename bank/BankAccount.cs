namespace bank;

internal class BankAccount
{
    private List<Transaction> _allTransaction = new List<Transaction>();
    public string Owner { get; private set; }
    public string Number { get; }
    public decimal Balance 
    {
        get
        {
            decimal balace = 0;
            foreach (var transaction in _allTransaction)
            {
                balace += transaction.Amount;
            }
            return balace;
        }
    }
    private static int s_accountNumberSeed = 10000000;

    public BankAccount(string name, decimal initialBalance)
    {
        MakeDeposite(initialBalance, DateTime.UtcNow, "initial balance"); //this .Balance = initialBalance;
        Owner = name;
        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;

    }

    public void MakeDeposite(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be positive");
        }
        var deposite = new Transaction(amount, date, note);
        _allTransaction.Add(deposite);
    }
    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
        }
        if (Balance < amount)
        {
            throw new InvalidOperationException("Not sufficient money for this withdrawal");
        }
        var withdrawal = new Transaction(-amount, date, note);
        _allTransaction.Add(withdrawal);
    }
}
