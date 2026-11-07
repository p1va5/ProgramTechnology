using GuessNumber.Input;

namespace GuessNumber.Logics;

public class GameLogic : ILogic
{
    private readonly IInput _input;
    public GameLogic(IInput input)
    {
        _input = input;
    }
    public bool Round(int secret)
    {
        int input = _input.InputNumber(1, 100);
        if (secret < input)
        {
            Console.WriteLine("Меньше");
            return false;
        }
        if (secret > input)
        {
            Console.WriteLine("Больше");
            return false;
        }
        return true;
    }
    public int CounterRound(int secret)
    {
        int CountRound = 0;
        while (true)
        {
            CountRound++;
            if (Round(secret)) return CountRound;
        }
    }
}
