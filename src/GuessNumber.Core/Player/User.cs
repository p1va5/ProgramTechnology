using GuessNumber.Core.Setting;
using GuessNumber.Core.Statistic;

namespace GuessNumber.Core.Player;
public class User
{
    public string Name { get; }
    public Dictionary<string, Statistic.Statistic> Statistics { get; set; } = new();
    public Settings Settings { get; set; } = Settings.Easy;
    public User(string name)
    {
        Name= name;
    }
    public IStatistic GetStatistic()
    {
        string level = Settings.Level;
        if (!Statistics.TryGetValue(level, out var statistic))
        {
            statistic = new Statistic.Statistic(level);
            Statistics.Add(level, statistic);
        }
        return statistic;
    }
}
