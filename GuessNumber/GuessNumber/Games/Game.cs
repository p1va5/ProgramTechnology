using GuessNumber.Logics;
using GuessNumber.Secret;
using GuessNumber.Statistics;

namespace GuessNumber.Games;

internal class Game : IGame
{
    private readonly ISecretNum _secret;
    private readonly ILogic _logic;
    private readonly IStatistic _statistic;
    public Game(ISecretNum secret, ILogic logic, IStatistic statistic)
    {
        _secret = secret;
        _logic= logic;
        _statistic = statistic;
    }

    public void Play()
    {
        char playAgain;
        do
        {
            int num = _secret.GetNumber(1, 100);
            int counter = _logic.CounterRound(num);
            Console.WriteLine("Ещё раз?(y)");
            playAgain = Convert.ToChar(Console.ReadLine());
            _statistic.AddStatistic(counter);
        } while (playAgain=='y');
        _statistic.ShowStatistic();
    }
}
