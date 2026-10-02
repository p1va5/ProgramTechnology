namespace bank;
/// <summary>
/// тип данных не изменяемый
/// </summary>
/// <param name="Amount">Сумма транзакции</param>
/// <param name="Date">Дата транзакции</param>
/// <param name="Note">Заметка транзакции</param>
public record Transaction(decimal Amount, DateTime Date, string Note);