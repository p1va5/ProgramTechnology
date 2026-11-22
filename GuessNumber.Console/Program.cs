using GuessNumber.Core.Game;
using GuessNumber.Core.Secret;

namespace GuessNumber.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                System.Console.Clear();
                System.Console.WriteLine("1. Играть");
                System.Console.WriteLine("2. Выйти");
                int choice = Convert.ToInt32(System.Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Play();
                        break;
                    case 2:
                        return;
                }
            }
        }
        static void Play()
        {
            ISecret secret = new RandomNumber();
            Game game = new Game(secret);
            System.Console.WriteLine("Введите число");
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
    }
}
