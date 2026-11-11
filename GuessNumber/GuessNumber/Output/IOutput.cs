using GuessNumber.Logics;
namespace GuessNumber.Output;

public interface IOutput
{
    public void ShowResult(object? sender, RoundEvents e);
    public void ShowStatistic(string text);
}
