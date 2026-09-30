namespace Class;

/// <summary>
/// Смена в кофейне.
/// </summary>
public class Shift
{
    /// <summary>
    /// Первичный ключ.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название смены (например, "Утренняя").
    /// </summary>
    public string Time { get; set; }

    /// <summary>
    /// Дата смены.
    /// </summary>
    public DateTime Date { get; set; }
    public Shift(int id, string time, DateTime date)
    {
        if (time is null) throw new ArgumentNullException(nameof(time), "Time is null");
        Id = id;
        Time = time;
        Date = date;
    }
    public bool IsMorning()
    {
        if (Time == "Утренняя") return true;
        return false;
    }
    public string GetInfo()
    {
        return Time + " (" + Date.ToString("dd.MM.yyyy") + ")";
    }
}
