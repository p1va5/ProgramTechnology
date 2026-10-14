namespace BarDrinks;
/// <summary>
/// Дочерний класс.
/// Безалкогольный коктейль.
/// </summary>
internal class Mocktail : Cocktail, IMixable
{
    /// <summary>
    /// Основной вкус.
    /// </summary>
    public string MainFlavor { get; set; }
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="id">Уникальный индефикатор.</param>
    /// <param name="name">Название напитка.</param>
    /// <param name="volume">Объем.</param>
    /// <param name="mainFlavor">Основной вкус.</param>
    public Mocktail(int id, string name, int volume, string mainFlavor) : base(id, name, volume)
    {
        MainFlavor = mainFlavor;
    }
    /// <summary>
    /// Метод, который проверят основной вкус фруктовый.
    /// </summary>
    public bool IsFruity => MainFlavor == "fruit" || MainFlavor == "lime" || MainFlavor == "berry" || MainFlavor == "citrus";
    /// <summary>
    /// Приготовление коктейля.
    /// </summary>
    public override void Prepare()
    {
        Console.WriteLine($"{Name} prepared.");
    }
    /// <summary>
    /// Смешивает коктейль с указанным ингредиентом.
    /// </summary>
    /// <param name="ingredient">Название ингредиента для смешивания.</param>
    public void Mix(string ingredient)
    {
        Console.WriteLine($"{Name} mixed with {ingredient}.");
    }
    /// <summary>
    /// Формирует строку с характеристиками коктейля.
    /// </summary>
    /// <returns>Возращает строку с характеристиками коктейля.</returns>
    public override string ToString()
    {
        return $"[Mocktail] {Name}, {Volume} ml, alcohol: {Alcohol}\n volume in oz: {VolumeInOz:0.0#}";
    }

}
