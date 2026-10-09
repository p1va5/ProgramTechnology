using System.Security.Cryptography.X509Certificates;

namespace bank;
/// <summary>
/// Представляет сберегательный/накопительный банковский счет, на который начисляются ежемесячные проценты.
/// Наследуется от класса <see cref="BankAccount"/>.
/// </summary>
public class InterestEarningAccount :BankAccount
{
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="InterestEarningAccount"/>.
    /// </summary>
    /// <param name="name">Имя владельца счета.</param>
    /// <param name="initialBalance">Начальный баланс счета.</param>
    public InterestEarningAccount(string name, decimal initialBalance):base(name, initialBalance)
    {

    }
    //override позволяет в дочернем классе опеределить новую реализацию метода
    /// <summary>
    /// Переопределяет метод базового класса для выполнения ежемесячных транзакций.
    /// Автоматически рассчитывает и начисляет проценты в размере 2% на остаток по счету, 
    /// если текущий баланс превышает 500 денежных единиц.
    /// </summary>
    public override void PerformMonthAndTransactions()
    {
        if(Balance>500m)
        {
            decimal iterest = Balance * 0.02m;
            MakeDeposite(iterest, DateTime.UtcNow, "Apply month intetrest");
        }
    }
}
