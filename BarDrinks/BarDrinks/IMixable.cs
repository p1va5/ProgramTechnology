namespace BarDrinks;
/// <summary>
/// Интерфейс для объектов которые поддерживают смешивание с игредиентами.
/// </summary>
internal interface IMixable
{
    /// <summary>
    /// Выполняет смешивание объекта с указанным ингредиентом.
    /// </summary>
    /// <param name="ingredient">Название ингредиента, используемого для смешивания.</param>
    void Mix(string ingredient);
}