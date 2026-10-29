namespace BankAccounts.Core.Time;
//Реализация для продакшена  реально вермя
public sealed class SystemClock : IClock
{
    public DateTime Now => DateTime.UtcNow;
}
