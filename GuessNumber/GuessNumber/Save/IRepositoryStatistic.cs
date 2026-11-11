using GuessNumber.Statistics;

namespace GuessNumber.Save;

public interface IRepositoryStatistic
{
    void Save(StatisticDto statistic);
    StatisticDto Load();
}
