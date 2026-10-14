namespace BarDrinks;
/// <summary>
/// Дочерний класс.
/// Классический коктейль.
/// </summary>
internal class ClassicCocktail : Cocktail
{
    /// <summary>
    /// Основной алкоголь.
    /// </summary>
    public string BaseSpirit {  get; set; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="id">Уникальный индефикатор.</param>
    /// <param name="name">Название напитка.</param>
    /// <param name="volume">Объем.</param>
    /// <param name="baseSpirit">Основа.</param>
    public ClassicCocktail(int id, string name, int volume, string baseSpirit) : base(id, name, volume)
    {
        BaseSpirit = baseSpirit;
    }
    /// <summary>
    /// Метод, который проверяет уроверь алкоголя.
    /// </summary>
    public bool IsStrong => Alcohol == AlcoholLevel.High;
    /// <summary>
    /// Приготовление коктейля.
    /// </summary>
    public override void Prepare()
    {
        Console.WriteLine($"{Name} prepared.");
    }
    /// <summary>
    /// Формирует строку с характеристиками коктейля.
    /// </summary>
    /// <returns>Возращает строку с характеристиками коктейля.</returns>
    public override string ToString()
    {
        return $"[ClassicCocktail] {Name}, {Volume} ml, alcohol: {Alcohol}, base: {BaseSpirit}\n volume in oz: {VolumeInOz:0.0#}";
    }
}
