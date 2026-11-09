using GuessNumber.Input;
using GuessNumber.Output;

namespace GuessNumber.Logics;

public class GameLogic : ILogic
{
    private readonly IInput _input;
    private readonly IOutput _output;
    public GameLogic(IInput input, IOutput output)
    {
        _input = input;
        _output = output;
    }
    public ResultRound Round(int secret)
    {
        int input = _input.InputNumber(1, 100);
        if (secret < input) return ResultRound.Lower;
        if (secret > input) return ResultRound.Higher;
        return ResultRound.Correct;
    }
    public int CounterRound(int secret)
    {
        int CountRound = 0;
        ResultRound result;
        while (true)
        {
            CountRound++;
            result = Round(secret);
            if (result == ResultRound.Correct) return CountRound;
            _output.GetResult(result);
        }
    }
}
