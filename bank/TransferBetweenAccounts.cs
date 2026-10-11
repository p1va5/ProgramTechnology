namespace bank;

public static class TransferBetweenAccounts
{
    public static void Transfer(BankAccount from, BankAccount to, decimal amount)
    {
        ArgumentNullException.ThrowIfNull(from);
        ArgumentNullException.ThrowIfNull(to);
        if(from == to) throw new ArgumentException("You cannot transfer funds to yourself.");
        if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be positive");
        from.MakeWithdrawal(amount, DateTime.UtcNow, "Transfer", "Transfer");
        to.MakeDeposite(amount, DateTime.UtcNow, "Transfer", "Transfer");
    }
}
