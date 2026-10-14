namespace BarDrinks;
/// <summary>
/// Базовй абстрактный класс.
/// </summary>
public abstract class Cocktail
{
    /// <summary>
    /// Уникальный идефикатор.
    /// </summary>
    private int _id;
    /// <summary>
    /// Название напитка.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Объем коктеля в мл.
    /// </summary>
    public int Volume { get; set; }
    /// <summary>
    /// Уровень алкоголя.
    /// </summary>
    public AlcoholLevel Alcohol { get; set; } = AlcoholLevel.None;
    /// <summary>
    /// Объем в унциях
    /// </summary>
    public double VolumeInOz => Volume / 30.0;
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Уникальный идефикатор.</param>
    /// <param name="name">Название напитка.</param>
    /// <param name="volume">Объем коктеля в мл.</param>
    public Cocktail(int id, string name, int volume)
    {
        _id = id;
        Name= name;
        Volume = volume;
    }
    /// <summary>
    /// Тоже конструктор.
    /// Принимает толко name а остальное заполняет 0.
    /// </summary>
    /// <param name="name">Название напитка.</param>
    public Cocktail(string name) : this(0, name, 0)
    {

    }
    /// <summary>
    /// Приготавление коктейля.
    /// Реализуется в других классах.
    /// </summary>
    public abstract void Prepare();
}
