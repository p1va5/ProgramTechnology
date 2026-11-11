using GuessNumber.Statistics;

namespace GuessNumber.Save;

public interface IRepository
{
    void Save(StatisticDto statistic);
    StatisticDto Load();
}
