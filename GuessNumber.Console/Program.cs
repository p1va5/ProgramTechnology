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
                int choice = Convert.ToInt32(System.Console.ReadLine());
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
        static void Play(ISecret secret, Settings settings)
        {
            Game game = new Game(secret, settings);
            System.Console.WriteLine($"Введите число ({settings.Min},{settings.Max})");
            int input = Convert.ToInt32(System.Console.ReadLine());
            game.Check += (s, e) => System.Console.WriteLine(Result(e));
            while (!game.Round(input))
            {
                System.Console.WriteLine("Введите число");
                input = Convert.ToInt32(System.Console.ReadLine());
            }    
        }
        static string Result(RoundCheckEventArgs e)
        {
            if (e.RoundResult == RoundResult.High) return "Больше";
            if (e.RoundResult == RoundResult.Lower) return "Меньше";
            return "Победа";
        }
        static Settings ChoiceSettings()
        {
            System.Console.WriteLine($"1. Легкий 1-50");
            System.Console.WriteLine($"2. Средний 1-100");
            System.Console.WriteLine($"3. Тяжёлый 1-1000");
            int choice = Convert.ToInt32(System.Console.ReadLine());
            switch (choice)
            {
                case 1:
                    return Settings.Easy;
                case 2:
                    return Settings.Medium;
                case 3:
                    return Settings.Hard;
                default:
                    return Settings.Easy;
            }
        }
    }
}
