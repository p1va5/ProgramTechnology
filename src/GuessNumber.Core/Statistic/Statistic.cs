using GuessNumber.Core.Setting;

namespace GuessNumber.Core.Statistic;

public class Statistic : IStatistic
{
    public string Level { get; }
    public int Min { get; set; }
    public int Max { get; set; }
    public int Count { get; set; }
    public  int CountGame { get; set; }
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
