using GuessNumber.Core.Game;
using GuessNumber.Core.Player;
using GuessNumber.Core.Secret;
using GuessNumber.Core.Setting;
using GuessNumber.Core.Statistic;
using System.Xml.Linq;


namespace GuessNumber.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ISecret secret = new RandomNumber();
            var user = new Dictionary<string, User>();
            User curUser = SelectUser(user);
            while (true)
            {
                System.Console.WriteLine("1. Играть");
                System.Console.WriteLine("2. Cтатистика");
                System.Console.WriteLine("3. Настройки");
                System.Console.WriteLine("4. Выйти");
                string? input = System.Console.ReadLine();
                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            System.Console.Clear();
                            Play(secret, curUser.Settings, curUser.GetStatistic());
                            System.Console.Clear();
                            break;
                        case 2:
                            System.Console.Clear();
                            ShowStatistic(curUser.GetStatistic());
                            break;
                        case 3:
                            System.Console.Clear();
                            curUser.Settings = ChoiceSettings();
                            System.Console.Clear();
                            break;
                        case 4:
                            return;
                    }
                }
            }
        }
        static void Play(ISecret secret, Settings settings, IStatistic statistic)
        {
            Game game = new Game(secret, settings);
            bool flag = false;
            int count = 0;
            game.Check += (s, e) => System.Console.WriteLine(Result(e));
            game.Finish += (s, e) => statistic.Add(e.Count);
            while (!flag)
            {
                System.Console.WriteLine($"Введите число ({settings.Min},{settings.Max})");
                string? input = System.Console.ReadLine();
                if (int.TryParse(input, out int inp))
                {
                    count++;
                    flag = game.Round(inp, count);
                }
            }
        }
        static string Result(RoundCheckEventArgs e)
        {
            if (e.RoundResult == RoundResult.High) return "Больше";
            if (e.RoundResult == RoundResult.Lower) return "Меньше";
            return "Победа";
        }
        static string RussianLevel(string level)
        {
            switch (level)
            {
                case "Easy":
                    return "Легкий";
                case "Medium":
                    return "Средний";
                case "Hard":
                    return "Сложный";
            }
            throw new ArgumentOutOfRangeException(nameof(level), level, "Неизвестный уровень сложности.");
        }
        static User SelectUser(Dictionary<string, User> user)
        {
            while (true)
            {
                System.Console.WriteLine("Введите имя: ");
                string? input = System.Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) continue;
                if (!user.TryGetValue(input, out var cur))
                {
                    cur = new User(input);
                    user.Add(input, cur);
                }
                return cur;
            }
        }
        static void ShowStatistic(IStatistic statistic)
        {
            System.Console.WriteLine($"Уровень сложности: {RussianLevel(statistic.Level)}");
            System.Console.WriteLine($"Минимальное количество попыток: {statistic.Min}");
            System.Console.WriteLine($"Максимальное количество попыток: {statistic.Max}");
            if(statistic.CountGame == 0) System.Console.WriteLine($"AVG: 0");
            else System.Console.WriteLine($"AVG: {(double)statistic.Count / statistic.CountGame}");
        }
        static Settings ChoiceSettings()
        {
            System.Console.WriteLine($"1. Легкий ({Settings.Easy.Min}-{Settings.Easy.Max})");
            System.Console.WriteLine($"2. Средний ({Settings.Medium.Min}-{Settings.Medium.Max})");
            System.Console.WriteLine($"3. Тяжёлый ({Settings.Hard.Min}-{Settings.Hard.Max})");
            string? input = System.Console.ReadLine();
            if (int.TryParse(input, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        return Settings.Easy;
                    case 2:
                        return Settings.Medium;
                    case 3:
                        return Settings.Hard;
                }
            }
            return Settings.Easy;
        }
    }
}
