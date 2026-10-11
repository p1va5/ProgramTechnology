using System.Text;

namespace bank;
// потомок класса object

/// <summary>
/// Представляет банковский счёт клиента с возможностью внесения депозитов,
/// снятия средств, отслеживания истории транзакций и выполнения ежемесячных операций.
/// </summary>
public class BankAccount
{
    private readonly decimal _minBalance;
    private List<Transaction> _allTransaction = new List<Transaction>();
    /// <summary>
    /// Возвращает имя владельца счета.
    /// </summary>
    public string Owner { get; private set; }
    /// <summary>
    /// Возвращает уникальный номер счета.
    /// </summary>
    public string Number { get; }
    /// <summary>
    /// Возвращает текущий баланс счета, рассчитанный на основе истории транзакций.
    /// </summary>
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
    /// <summary>
    /// Возвращает статус клиента.
    /// </summary>
    public ClientStatus Status { get; set; } = ClientStatus.Regular;
    private static int s_accountNumberSeed = 10000000;
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="BankAccount"/> с нулевым минимальным балансом.
    /// </summary>
    /// <param name="name">Имя владельца счета.</param>
    /// <param name="initialBalance">Начальный баланс счета.</param>
    public BankAccount(string name, decimal initialBalance):this(name, initialBalance, 0, ClientStatus.Regular)
    {

    }
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="BankAccount"/> с указанием минимального баланса.
    /// </summary>
    /// <param name="name">Имя владельца счета.</param>
    /// <param name="initialBalance">Начальный баланс счета.</param>
    /// <param name="minBalance">Минимально допустимый баланс счета.</param>
    /// <param name="status">Статус клиента.</param>
    public BankAccount(string name, decimal initialBalance, decimal minBalance, ClientStatus status)
    {
        Owner = name;
        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;
        _minBalance = minBalance;
        Status = status;
        if (initialBalance > 0) MakeDeposite(initialBalance, DateTime.UtcNow, "initial balance"); //this .Balance = initialBalance;
    }
    /// <summary>
    /// Вносит депозит на счет.
    /// </summary>
    /// <param name="amount">Сумма депозита. Должна быть больше нуля.</param>
    /// <param name="date">Дата и время проведения транзакции.</param>
    /// <param name="note">Примечание или описание транзакции.</param>
    /// <param name="type">Тип тразакции.</param>
    /// <exception cref="ArgumentOutOfRangeException">Вызывается, если сумма депозита меньше или равна нулю.</exception>
    public void MakeDeposite(decimal amount, DateTime date, string note, string type = "Deposite")
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be positive");
        }
        var deposite = new Transaction(amount, date, note);
        _allTransaction.Add(deposite);
        AuditLogs.Add(Number, type, amount, date);

    }
    /// <summary>
    /// Снимает денежные средства со счета.
    /// </summary>
    /// <param name="amount">Сумма снятия. Должна быть больше нуля.</param>
    /// <param name="date">Дата и время проведения транзакции.</param>
    /// <param name="note">Примечание или описание транзакции.</param>
    /// <param name="type">Тип тразакции.</param>
    /// <exception cref="ArgumentOutOfRangeException">Вызывается, если сумма меньше или равна нулю.</exception>
    /// <exception cref="InvalidOperationException">Вызывается через <see cref="CheckWithdrawalLmit"/>, если баланс падает ниже минимального.</exception>
    public void MakeWithdrawal(decimal amount, DateTime date, string note, string type = "Withdrawal")
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
        Transaction? overdraftTrasction = CheckWithdrawalLmit(Balance - amount < _minBalance);
        Transaction? withdrawal = new(-amount, date, note);
        _allTransaction.Add(withdrawal);
        AuditLogs.Add(Number, type, amount, date);
        if (overdraftTrasction is not null) _allTransaction.Add(overdraftTrasction);
        if (Status == ClientStatus.VIP) MakeDeposite(amount * 0.05m, date, "Cashback");
    }
    //protected модификатор доступа который означает что его можно вызвать текущего и из дочернего класса клиент не может его вызвать 
    /// <summary>
    /// Проверяет, превышает ли операция снятия лимит минимального баланса.
    /// Доступен для вызова в текущем классе и классах-наследниках.
    /// </summary>
    /// <param name="isOverdrawn">Значение, указывающее, нарушает ли операция лимит баланса.</param>
    /// <returns>Возвращает транзакцию овердрафта, если лимит превышен и это разрешено, либо <see langword="null"/>.</returns>
    /// <exception cref="InvalidOperationException">Вызывается, если на счету недостаточно средств.</exception>
    protected virtual Transaction? CheckWithdrawalLmit(bool isOverdrawn)
    {
        if (isOverdrawn)
        {
            throw new InvalidOperationException("Not sufficient rubls for whis withdrawal");
        }
        else return default;
    }
    /// <summary>
    /// Формирует строку с историей всех транзакций по счету.
    /// </summary>
    /// <returns>Строка, содержащая таблицу транзакций с датой, суммой, изменением баланса и описанием.</returns>
    public string GetAccountHistory()
    {
        var report = new StringBuilder();
        decimal balance = 0;
        report.Append("Data\t\tAmount\tBalance\tNote\n");
        foreach (var item in _allTransaction)
        {
            balance += item.Amount;
            report.AppendLine($"" + $"{item.Date.ToShortDateString()}\t" + $"{item.Amount}\t{balance}\t{item.Note}");
        }
        return report.ToString();
    }
    //virtual позволяет в дочернем классе предоставить другую реализацию в дочернем классе
    /// <summary>
    /// Выполняет ежемесячные транзакции (например, начисление процентов или снятие комиссии).
    /// Метод может быть переопределен в дочерних классах.
    /// </summary>
    public virtual void PerformMonthAndTransactions()
    {
        switch(Status)
        {
            case ClientStatus.Regular:
                MakeWithdrawal(50, DateTime.UtcNow, "Service fee");
                break;
            case ClientStatus.Premium:
                if(Balance>10000)
                {
                    decimal iterest = 0.01m * (Balance - 10000);
                    MakeDeposite(iterest, DateTime.UtcNow, "Monthly interest", "Interest");
                }
                break;
            case ClientStatus.VIP:
                if (Balance > 10000)
                {
                    decimal iterest = 0.03m * (Balance - 10000);
                    MakeDeposite(iterest, DateTime.UtcNow, "Monthly interest", "Interest");
                }
                break;
        }
    }
    // преропеделяем метод базового класса object tostring возращает строку и нформацию о обекте
    /// <summary>
    /// Переопределяет метод базового класса <see cref="object"/> и возвращает строковое представление информации о счете.
    /// </summary>
    /// <returns>Строка с именем владельца, номером счета и его типом.</returns>
    public override string ToString()
    {
        return $"Owner: {Owner}\taccount number: {Number} (тип счета{GetType()}) ";
    }
}

