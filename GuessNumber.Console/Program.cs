using GuessNumber.Core.Game;
using GuessNumber.Core.Secret;
using GuessNumber.Core.Setting;

namespace GuessNumber.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ISecret secret = new RandomNumber();
            Settings settings = Settings.Easy;
            while (true)
            {
                System.Console.Clear();
                System.Console.WriteLine("1. Играть");
                System.Console.WriteLine("2. Настройки");
                System.Console.WriteLine("3. Выйти");
                string? input = System.Console.ReadLine();
                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Play(secret, settings);
                            break;
                        case 2:
                            settings = ChoiceSettings();
                            break;
                        case 3:
                            return;
                    }
                }
            }
        }
        static void Play(ISecret secret, Settings settings)
        {
            Game game = new Game(secret, settings);
            bool flag = false;
            game.Check += (s, e) => System.Console.WriteLine(Result(e));
            while (!flag)
            {
                System.Console.WriteLine($"Введите число ({settings.Min},{settings.Max})");
                string? input = System.Console.ReadLine();
                if (int.TryParse(input, out int inp)) flag = game.Round(inp);
            }
        }
        static string Result(RoundCheckEventArgs e)
        {
            if (e.RoundResult == RoundResult.High) return "Больше";
            if (e.RoundResult == RoundResult.Lower) return "Меньше";
            return "Победа!";
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
