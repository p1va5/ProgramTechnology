namespace Class;

internal class InMemoryRepository
{
    private List<Barista> _baristas;
    private List<Shift> _shifts;
    private List<Drink> _drinks;
    public InMemoryRepository()
    {
        _baristas = new List<Barista>()
        {
            new Barista(1,"Петров П.П.", 3, 4.8),
            new Barista(2, "Павлов В.И.", 2, 3.7),
            new Barista(3, "Иванов И.И.", 5, 1.9),
            new Barista(4, "Сидоров А.Р.", 7, 2.3),
            new Barista(5, "Кузнецов П.Д.", 1, 4.5),
            new Barista(6, "Смирнов Д.В.",  2, 4.1),
            //new Barista(7, "Тест Т.Т.",  2, -4.1)

        };

        _shifts = new List<Shift>()
        {
            new Shift(1, "Утренняя", new DateTime(2025, 9, 1)),
            new Shift(2, "Дневная",  new DateTime(2025, 9, 1)),
            new Shift(3, "Вечерняя", new DateTime(2025, 9, 1)),
            new Shift(4, "Утренняя", new DateTime(2025, 9, 2)),
            new Shift(5, "Дневная",  new DateTime(2025, 9, 2)),
            new Shift(6, "Вечерняя", new DateTime(2025, 9, 2)),
            new Shift(7, "Утренняя", new DateTime(2025, 9, 3)),
            new Shift(8, "Дневная",  new DateTime(2025, 9, 3)),
            new Shift(9, "Вечерняя", new DateTime(2025, 9, 3))
        };

        _drinks = new List<Drink>()
        {
            new Drink(1, "Латте", 1, 1, 200, 300),
            new Drink(2, "Американо", 2, 3, 180, 300),
            new Drink(3, "Эспрессо", 2, 3, 190, 270),
            new Drink(4, "Раф", 3, 5, 250, 250),
            new Drink(5, "Мокко", 3, 5, 200, 270),
            new Drink(6, "Капучино", 4, 3, 220, 250),
            new Drink(7, "Черный чай", 4, 3, 210, 300),
            new Drink(8, "Зеленый чай", 5, 2, 180, 270),
            new Drink(9, "Улун", 5, 2, 190, 300),
            new Drink(10, "Ромашковый чай", 6, 3, 200, 300),
            new Drink(11, "Имбирный чай", 6, 3, 210, 250),
            new Drink(12, "Красный чай", 7, 6, 220, 250),
            //new Drink(13, "Тест", 7, 6, -2, -2)
        };
    }
    public List<Barista> GetBaristas() { return _baristas; }
    public List<Shift> GetShifts() { return _shifts; }
    public List<Drink> GetDrinks() { return _drinks; }
}
