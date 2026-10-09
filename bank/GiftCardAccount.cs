namespace bank;

internal class GiftCardAccount:BankAccount
{
    /// <summary>
    /// Сумма ежемесячного пополнения счета.
    /// </summary>
    private readonly decimal _monthyDeposit=0m;
    //monthyDeposit по умолчанию принимает 0 при создание обекта new GiftCardAccount("Yana", 1000) monthyDeposit=0
    // new GiftCardAccount("Yana", 1000, 1000) monthyDeposit=1000
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="GiftCardAccount"/>.
    /// </summary>
    /// <param name="name">Имя владельца счета.</param>
    /// <param name="initialBalance">Начальный баланс счета.</param>
    /// <param name="monthyDeposit">Сумма ежемесячного автоматического пополнения. Если не указана при вызове других перегрузок, по умолчанию равна 0.</param>
    public GiftCardAccount(string name, decimal initialBalance, decimal monthyDeposit) : base(name, initialBalance) => _monthyDeposit = monthyDeposit;
    /// <summary>
    /// Переопределяет метод базового класса для выполнения ежемесячных транзакций.
    /// Автоматически вносит депозит в размере <see cref="_monthyDeposit"/>, если его значение не равно нулю.
    /// </summary>
    public override void PerformMonthAndTransactions()
    {
        if(_monthyDeposit != 0)
        {
            MakeDeposite(_monthyDeposit, DateTime.UtcNow, "Add monthy deposit");
        }
    }
    /// <summary>
    /// Переопределяет метод базового класса <see cref="BankAccount"/> и возвращает строковое представление информации о подарочном счете.
    /// </summary>
    /// <returns>Строка с базовой информацией о счете, дополненная суммой ежемесячного пополнения.</returns>
    public override string ToString()
    {
        return base.ToString()+$"monthy deposit: {_monthyDeposit}";
    }
}
