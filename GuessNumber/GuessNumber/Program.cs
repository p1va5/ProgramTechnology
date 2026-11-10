using GuessNumber.Games;
using GuessNumber.Input;
using GuessNumber.Logics;
using GuessNumber.Output;
using GuessNumber.Secret;
using GuessNumber.Statistics;

namespace GuessNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IInput input = new InputConsole();
            IOutput output = new OutputConsole();
            ILogic logic = new GameLogic(input);
            logic.RoundFinished += output.GetResult;
            ISecretNum secret = new RandomNubmer();
            IStatistic statistic = new ConsoleStatistic();
            IGame game = new Game(secret, logic, statistic, input, output);
            game.Play();
        }
    }
}
