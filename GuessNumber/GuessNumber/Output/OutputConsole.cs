using GuessNumber.Logics;

namespace GuessNumber.Output;

public class OutputConsole : IOutput
{
    public void ShowResult(object? sender, RoundEvents e)
    {
        if (e.Result == ResultRound.Higher) Console.WriteLine("Больше");
        if (e.Result == ResultRound.Lower) Console.WriteLine("Меньше");
    }

    public void ShowStatistic(string text)
    {
        Console.WriteLine(text);
    }
}
