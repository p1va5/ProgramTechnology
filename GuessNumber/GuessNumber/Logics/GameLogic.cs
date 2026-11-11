using GuessNumber.Input;

namespace GuessNumber.Logics;

public class GameLogic : ILogic
{
    private readonly IInput _input;
    public event EventHandler<RoundEvents>? RoundFinished;

    public GameLogic(IInput input)
    {
        _input = input;
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
        int countRound = 0;
        ResultRound result;

        while (true)
        {
            countRound++;
            result = Round(secret);
            RoundFinished?.Invoke(this, new RoundEvents(result, countRound));
            if (result == ResultRound.Correct)
            {
                return countRound;
            }
        }
    }
}