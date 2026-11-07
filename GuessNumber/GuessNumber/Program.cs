using GuessNumber.Games;
using GuessNumber.Input;
using GuessNumber.Logics;
using GuessNumber.Secret;
using GuessNumber.Statistics;

namespace GuessNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IInput input = new InputConsole();
            ILogic logic = new GameLogic(input);
            ISecretNum secret = new RandomNubmer();
            IStatistic statistic = new ConsoleStatistic();
            IGame game = new Game(secret, logic, statistic, input);
            game.Play();
        }
    }
}
