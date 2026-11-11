namespace GuessNumber.GameSettings;

public class DifficultySelector : ISelector
{
    private readonly IReadOnlyList<DifficultyList> _options;

    public DifficultySelector(IReadOnlyList<DifficultyList> options)
    {
        _options = options;
    }

    public Setting Select()
    {
        Console.WriteLine("Выберите сложность:");
        for (int i = 0; i < _options.Count; i++)
        {
            var option = _options[i];
            Console.WriteLine($"{i + 1}. {option.Name} ({option.Min}–{option.Max})");
        }
        while (true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= _options.Count)
            {
                var option = _options[choice - 1];
                return new Setting(option.Difficulty, option.Min, option.Max);
            }
            Console.WriteLine("Некорректный ввод");
        }
    }
}
