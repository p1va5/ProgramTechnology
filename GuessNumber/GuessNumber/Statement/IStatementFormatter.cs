using GuessNumber.Statistics;

namespace GuessNumber.Statement;
public interface IStatementFormatter
{
    public string Format(StatisticDto transactions);
}
