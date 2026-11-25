using GuessNumber.Core.Setting;

namespace GuessNumber.Core.Statistic;

public class Statistic : IStatistic
{
    public string Level { get; }
    public int Min { get; private set; }
    public int Max { get; private set; }
    public int Count { get; private set; }
    public  int CountGame { get; private set; }
    public Statistic(string level)
    { 
        Level = level;
    }
    public void Add(int counter)
    {
        if (CountGame == 0 || counter < Min) Min = counter;
        if (counter > Max) Max = counter;
        Count += counter;
        CountGame++;
    }
}
