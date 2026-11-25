using GuessNumber.Core.Setting;
using GuessNumber.Core.Statistic;

namespace GuessNumber.Core.Player;
public class User
{
    public string Name { get; }
    private readonly Dictionary<string, IStatistic> _statistics = new();
    public Settings Settings { get; set; } = Settings.Easy;
    public User(string name)
    {
        Name= name;
    }
    public IStatistic GetStatistic()
    {
        string level = Settings.Level;
        if (!_statistics.TryGetValue(level, out var statistic))
        {
            statistic = new Statistic.Statistic(level);
            _statistics.Add(level, statistic);
        }
        return statistic;
    }
}
