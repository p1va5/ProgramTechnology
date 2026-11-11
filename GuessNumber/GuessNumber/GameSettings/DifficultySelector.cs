namespace GuessNumber.GameSettings;

public class DifficultySelector : ISelector
{
    public Setting Select()
    {
        Console.WriteLine("Выберите сложность:");
        Console.WriteLine("1. Лёгкая (1–50)");
        Console.WriteLine("2. Средняя (1–100)");
        Console.WriteLine("3. Сложная (1–500)");
        while (true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        return new Setting(Difficulty.Easy, 1, 50);
                    case 2:
                        return new Setting(Difficulty.Medium, 1, 100);
                    case 3:
                        return new Setting(Difficulty.Hard, 1, 500);
                }
            }
            Console.WriteLine("Некорректный ввод");
        }

    }
}
