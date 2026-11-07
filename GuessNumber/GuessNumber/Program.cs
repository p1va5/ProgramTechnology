using GuessNumber.Games;
using GuessNumber.Logics;
using GuessNumber.Secret;
using GuessNumber.Statistics;

namespace GuessNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ILogic logic = new GameLogic();
            ISecretNum secret = new RandomNubmer();
            IStatistic statistic = new ConsoleStatistic();
            IGame game = new Game(secret, logic, statistic);
            game.Play();
        }
    }
}
