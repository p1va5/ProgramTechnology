using System.Timers;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Class;

public class Barista
{
    /// <summary>
    /// Первичный ключ
    /// </summary>
    public int Id { get; set;}
    /// <summary>
    /// Фио баристы
    /// </summary>
    public string FullName { get; set; }
    /// <summary>
    /// Сколько работает
    /// </summary>
    public int Experience { get; set; }
    /// <summary>
    /// Рейтинг баристы
    /// </summary>
    public double Rating { get; set; }
    public Barista(int id, string fullName, int experience, double rating)
    {
        Id = id;
        if (fullName is null) throw new ArgumentNullException(nameof(fullName), "FullName is null");
        FullName = fullName;
        if (experience < 0) throw new ArgumentOutOfRangeException(nameof(experience), "The experience cannot be negative.");
        Experience = experience;
        if (rating < 0 || rating > 5) throw new ArgumentOutOfRangeException(nameof(rating), "Rating from 0 to 5.");
        Rating = rating;
    }
    public bool IsExperience()
    {
        if (Experience > 2) return true;
        return false;
    }
    public string GetInfo()
    {
        return FullName + " (" + Experience + " года, рейтинг " + Rating + ")";
    }
}
