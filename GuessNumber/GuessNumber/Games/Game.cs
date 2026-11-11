using GuessNumber.Input;
using GuessNumber.Logics;
using GuessNumber.Output;
using GuessNumber.Save;
using GuessNumber.Secret;
using GuessNumber.Statement;
using GuessNumber.Statistics;
using GuessNumber.GameSettings;

namespace GuessNumber.Games;

internal class Game : IGame
{
    private readonly ISecretNum _secret;
    private readonly ILogic _logic;
    private readonly IStatistic _statistic;
    private readonly IStatementFormatter _formatter;
    private readonly IInput _input;
    private readonly IOutput _output;
    private readonly IRepositoryStatistic _statisticRepository;
    private readonly IRepositorySettings _repositorySettings;
    private readonly Setting _settings;
    public Game(ISecretNum secret, ILogic logic, IStatistic statistic, IInput input, IOutput output, IStatementFormatter formatter, IRepositoryStatistic statisticRepository, IRepositorySettings repositorySettings, Setting settings)
    {
        _secret = secret;
        _logic= logic;
        _statistic = statistic;
        _input = input;
        _output = output;
        _formatter = formatter;
        _statisticRepository = statisticRepository;
        _settings = settings;
        _repositorySettings = repositorySettings;
    }

    public void Play()
    {
        _statisticRepository.Load();
        _repositorySettings.Load();
        bool playAgain;
        do
        {
            int num = _secret.GetNumber(_settings.Min, _settings.Max);
            int counter = _logic.CounterRound(num);
            _statistic.Add(counter);
            playAgain = _input.AskAgain();
        } while (playAgain);
        _output.ShowStatistic(_formatter.Format(_statistic.Get()));
        _statisticRepository.Save(_statistic.Get());
        _repositorySettings.Save(_settings);
    }
}
