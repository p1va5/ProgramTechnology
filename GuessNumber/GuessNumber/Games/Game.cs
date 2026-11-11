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
    private ILogic _logic;
    private readonly IStatistic _statistic;
    private readonly IStatementFormatter _formatter;
    private readonly IInput _input;
    private readonly IOutput _output;
    private readonly IRepositoryStatistic _statisticRepository;
    private readonly IRepositorySettings _repositorySettings;
    private readonly ISelector _selector;
    private Setting _settings;
    public Game(ISecretNum secret, ILogic logic, IStatistic statistic, IInput input, IOutput output, IStatementFormatter formatter, IRepositoryStatistic statisticRepository, IRepositorySettings repositorySettings, Setting settings,ISelector selector)
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
        _selector = selector;
    }

    public void Play()
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine("1. Играть");
            Console.WriteLine("2. Статистика");
            Console.WriteLine("3. Настройки");
            Console.WriteLine("4. Выйти");
            bool playAgain;
            string input = Console.ReadLine();
            if (int.TryParse(input, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        do
                        {
                            Console.Clear();
                            int num = _secret.GetNumber(_settings.Min, _settings.Max);
                            int counter = _logic.CounterRound(num);
                            _statistic.Add(counter);
                            playAgain = _input.AskAgain();
                            Console.Clear();
                        } while (playAgain);
                        _statisticRepository.Save(_statistic.Get());
                        _repositorySettings.Save(_settings);
                        break;
                    case 2:
                        Console.Clear();
                        _output.ShowStatistic(_formatter.Format(_statistic.Get()));
                        break;
                    case 3:
                        Console.Clear();
                        _logic.RoundFinished -= _output.ShowResult;
                        _settings = _selector.Select();
                        _repositorySettings.Save(_settings);
                        _logic = new GameLogic(_input, _settings);
                        _logic.RoundFinished += _output.ShowResult;
                        Console.Clear();
                        break;
                    case 4:
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Некорректный ввод");
                        break;
                }
            }
        }
    }
}
