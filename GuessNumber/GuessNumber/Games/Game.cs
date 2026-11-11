using GuessNumber.Input;
using GuessNumber.Logics;
using GuessNumber.Output;
using GuessNumber.Save;
using GuessNumber.Secret;
using GuessNumber.Statement;
using GuessNumber.Statistics;

namespace GuessNumber.Games;

internal class Game : IGame
{
    private readonly ISecretNum _secret;
    private readonly ILogic _logic;
    private readonly IStatistic _statistic;
    private readonly IStatementFormatter _formatter;
    private readonly IInput _input;
    private readonly IOutput _output;
    private readonly IRepository _statisticRepository;
    public Game(ISecretNum secret, ILogic logic, IStatistic statistic, IInput input, IOutput output, IStatementFormatter formatter, IRepository statisticRepository)
    {
        _secret = secret;
        _logic= logic;
        _statistic = statistic;
        _input = input;
        _output = output;
        _formatter = formatter;
        _statisticRepository = statisticRepository;
    }

    public void Play()
    {
        _statisticRepository.Load();
        bool playAgain;
        do
        {
            int num = _secret.GetNumber(1, 100);
            int counter = _logic.CounterRound(num);
            _statistic.Add(counter);
            playAgain = _input.AskAgain();
        } while (playAgain);
        _output.ShowStatistic(_formatter.Format(_statistic.Get()));
        _statisticRepository.Save(_statistic.Get());
    }
}
