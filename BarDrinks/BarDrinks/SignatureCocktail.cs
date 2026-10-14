namespace BarDrinks;
/// <summary>
/// Дочерний класс.
/// Авторские коктейль.
/// </summary>
internal class SignatureCocktail : Cocktail, IMixable
{
    /// <summary>
    /// Имя автора.
    /// </summary>
    public string ChefName { get; set; }
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="id">Уникальный индефикатор.</param>
    /// <param name="name">Название напитка.</param>
    /// <param name="volume">Объем.</param>
    /// <param name="chefName">Автор.</param>
    public SignatureCocktail(int id, string name, int volume, string chefName) : base(id, name, volume)
    {
        ChefName = chefName;
    }
    /// <summary>
    /// Метод который проверяет, есть ли автор.
    /// </summary>
    public bool IsAuthorial => !string.IsNullOrWhiteSpace(ChefName);
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
        return $"[SignatureCocktail] {Name}, {Volume} ml, alcohol: {Alcohol}, Chef name: {ChefName}\n volume in oz: {VolumeInOz:0.0#}";
    }
}
