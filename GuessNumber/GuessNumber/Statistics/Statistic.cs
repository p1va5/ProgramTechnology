namespace GuessNumber.Statistics;
internal class Statistic : IStatistic
{
    private int _min = int.MaxValue;
    private int _max = 0;
    private int _count = 0;
    private int _countGame = 0;
    public Statistic(StatisticDto statistic)
    {
        _min = statistic.Min;
        _max = statistic.Max;
        _count = statistic.Count;
        _countGame = statistic.CountGame;
    }
    public void Add(int counter)
    {
        if (counter < _min) _min = counter;
        if (counter > _max) _max = counter;
        _count += counter;
        _countGame++;
    }
    public StatisticDto Get()
    {
        if (_countGame == 0) return new StatisticDto(0, 0, 0, 0);
        return new StatisticDto(_min, _max, _count, _countGame);
    }
}
