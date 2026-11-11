using GuessNumber.Games;
using GuessNumber.GameSettings;
using GuessNumber.Input;
using GuessNumber.Logics;
using GuessNumber.Output;
using GuessNumber.Save;
using GuessNumber.Secret;
using GuessNumber.Statement;
using GuessNumber.Statistics;

namespace GuessNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IInput input = new InputConsole();
            IOutput output = new OutputConsole();
            DifficultySelector selector = new DifficultySelector();
            IRepositorySettings repositorySettings = new SettingsRepository("settings.json");
            IRepositoryStatistic statisticRepository = new StatisticRepository("statistic.json");
            Setting setting;
            if (repositorySettings.FileExists()) setting = repositorySettings.Load();
            else setting = selector.Select();
            ILogic logic = new GameLogic(input, setting);
            IStatementFormatter formatter = new TextStatementFormatter();
            logic.RoundFinished += output.ShowResult;
            ISecretNum secret = new RandomNubmer();
            IStatistic statistic = new Statistic(statisticRepository.Load());
            IGame game = new Game(secret, logic, statistic, input, output, formatter, statisticRepository, repositorySettings, setting);
            game.Play();
        }
    }
}
