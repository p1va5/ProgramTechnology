namespace bank;

/// <summary>
/// Предоставляет метод для перевода денежных средств между банковскими счетами.
/// </summary>
public static class TransferBetweenAccounts
{
    /// <summary>
    /// Переводит денежные средства с одного банковского счёта на другой.
    /// </summary>
    /// <param name="from">Банковский счёт, с которого списываются средства.</param>
    /// <param name="to">Банковский счёт, на который зачисляются средства.</param>
    /// <param name="amount">Сумма перевода. Должна быть больше нуля.</param>
    /// <exception cref="ArgumentNullException">
    /// Выбрасывается, если исходный или целевой счёт равен null.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Выбрасывается, если исходный и целевой счета совпадают.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Выбрасывается, если сумма перевода меньше или равна нулю.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// Может быть выброшено, если на исходном счёте недостаточно средств
    /// для выполнения перевода.
    /// </exception>
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
