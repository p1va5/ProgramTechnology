namespace GuessNumber.Statistics;
internal interface IStatistic
{
    public void Add(int counter);
    public StatisticDto Get();

}
