using System.Data;

namespace bank;

/// <summary>
/// Представляет кредитный банковский счет (счет с кредитной линией).
/// Наследуется от класса <see cref="BankAccount"/> и позволяет балансу уходить в минус до определенного лимита.
/// </summary>
public class LineOfCreditAccount:BankAccount
{
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="LineOfCreditAccount"/> с указанием кредитного лимита.
    /// </summary>
    /// <param name="name">Имя владельца счета.</param>
    /// <param name="initialBalance">Начальный баланс счета.</param>
    /// <param name="creditLimit">Размер кредитного лимита (положительное число, которое передается в базовый конструктор как отрицательный минимальный баланс).</param>
    /// <param name="status">Статус клиента.</param>
    public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit, ClientStatus status = ClientStatus.Regular) :base(name, initialBalance, -creditLimit, status)
    {

    }
    /// <summary>
    /// Переопределяет метод базового класса для выполнения ежемесячных транзакций.
    /// Если баланс счета отрицательный, рассчитывает и списывает ежемесячную комиссию (проценты за пользование кредитом) 
    /// в размере 7% от суммы задолженности.
    /// </summary>
    public override void PerformMonthAndTransactions()
    {
        if(Balance<0)
        {
            decimal interest = -Balance * 0.07m;
            MakeWithdrawal(interest, DateTime.UtcNow, "Charge");
        }    
    }
    /// <summary>
    /// Переопределяет проверку лимита снятия средств. 
    /// Вместо генерации исключения, при превышении лимита накладывает штраф за овердрафт.
    /// </summary>
    /// <param name="isOverdrawn">Значение, указывающее, превышен ли установленный кредитный лимит.</param>
    /// <returns>
    /// Возвращает объект <see cref="Transaction"/> со штрафом в размере 20 денежных единиц, если лимит превышен; 
    /// в противном случае — <see langword="null"/>.
    /// </returns>
    protected override Transaction? CheckWithdrawalLmit(bool isOverdrawn) => isOverdrawn ? new Transaction(-20, DateTime.UtcNow, "Apply overdraft") : default;
}
