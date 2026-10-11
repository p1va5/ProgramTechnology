using System.Text;

namespace bank;
/// <summary>
/// Представляет запись об операции в журнале аудита банковских счетов.
/// </summary>
/// <param name="Number">Номер банковского счёта.</param>
/// <param name="Type">Тип операции: Deposit, Withdrawal или Interest.</param>
/// <param name="Amount">Сумма операции.</param>
/// <param name="Date">Дата и время выполнения операции.</param>
public record AuditLog(string Number, string Type, decimal Amount, DateTime Date);
/// <summary>
/// Предоставляет общий журнал аудита операций всех банковских счетов.
/// </summary>
public static class AuditLogs
{
    private static readonly List<AuditLog> _auditLog = new List<AuditLog>();
    /// <summary>
    /// Добавляет запись об операции в журнал аудита.
    /// </summary>
    /// <param name="number">Номер банковского счёта.</param>
    /// <param name="type">Тип операции.</param>
    /// <param name="amount">Сумма операции.</param>
    /// <param name="date">Дата и время операции.</param>
    public static void Add(string number, string type, decimal amount, DateTime date)
    {
        _auditLog.Add(new AuditLog(number, type, amount, date));
    }
    /// <summary>
    /// Формирует текстовое представление журнала аудита.
    /// </summary>
    /// <returns>Строка с записями аудита.</returns>
    public static string GetAuditLogs()
    {
        var log = new StringBuilder();
        log.Append("Number\t\tType\t\tAmount\tDate\n");
        foreach (var item in _auditLog)
        {
            log.AppendLine($"" + $"{item.Number}\t{item.Type}\t{item.Amount}\t"+$"{ item.Date.ToShortDateString()}\t");
        }
        return log.ToString();
    }
}