using GuessNumber.Statistics;

namespace GuessNumber.Statement;

public class TextStatementFormatter : IStatementFormatter
{
    public string Format(StatisticDto statistic)
    {
        return $"min = {statistic.Min} max= {statistic.Max} avg = {(double)statistic.Count / statistic.CountGame}";
    }
}
