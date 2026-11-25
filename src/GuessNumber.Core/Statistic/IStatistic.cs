namespace GuessNumber.Core.Statistic;

public interface IStatistic
{
    string Level { get; }
    int Min { get; }
    int Max { get; }
    int Count { get; }
    int CountGame { get; }
    void Add(int counter);
}
