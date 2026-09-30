using System.Timers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Class;

public class Drink
{
    /// <summary>
    /// Первичный ключ
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название напитка
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Внешний ключ смены
    /// </summary>
    public int ShiftId { get; set; }

    /// <summary>
    /// Внешний ключ бариста
    /// </summary>
    public int BaristaId { get; set; }

    /// <summary>
    /// Цена напитка в рублях
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Объём напитка в миллилитрах
    /// </summary>
    public int Volume { get; set; }

    public Drink(int id, string name, int shiftId, int baristaId, decimal price, int volume)
    {
        Id=id;
        if (name is null) throw new ArgumentNullException(nameof(name), "Name is null");
        Name = name;
        ShiftId=shiftId;
        BaristaId=baristaId;
        if(price<0) throw new ArgumentOutOfRangeException(nameof(price), "The price cannot be negative.");
        Price =price;
        if (volume < 0) throw new ArgumentOutOfRangeException(nameof(volume), "The volume cannot be negative.");
        Volume = volume;
    }
    public bool IsCoffee()
    {
        if(Name == "Улун" || (Name[Name.Length-3]=='ч' && Name[Name.Length - 2] == 'а' && Name[Name.Length - 1] == 'й')) return false;
        return true;
    }
    public string GetInfo()
    {
        return Name + " (" + Price + " руб., " + Volume + " мл)";
    }
}
