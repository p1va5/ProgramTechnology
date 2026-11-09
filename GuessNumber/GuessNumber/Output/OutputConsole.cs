namespace GuessNumber.Output;

public class OutputConsole : IOutput
{
    public void GetResult(ResultRound result)
    {
        if (result == ResultRound.Higher) Console.WriteLine("Больше");
        else Console.WriteLine("Меньше");
    }
}
