using GuessNumber.Input;
using GuessNumber.Logics;
using GuessNumber.Secret;
using GuessNumber.Statistics;

namespace GuessNumber.Games;

internal class Game : IGame
{
    private readonly ISecretNum _secret;
    private readonly ILogic _logic;
    private readonly IStatistic _statistic;
    private readonly IInput _input;
    public Game(ISecretNum secret, ILogic logic, IStatistic statistic, IInput input)
    {
        _secret = secret;
        _logic= logic;
        _statistic = statistic;
        _input = input;
    }

    public void Play()
    {
        bool playAgain;
        do
        {
            int num = _secret.GetNumber(1, 100);
            int counter = _logic.CounterRound(num);
            _statistic.AddStatistic(counter);
            playAgain = _input.AskAgain();
        } while (playAgain);
        _statistic.ShowStatistic();
    }
}
