namespace GuessNumber.Logics;

public class RoundEvents
{
    public ResultRound Result { get; }
    public int Count { get; }
    public RoundEvents(ResultRound result, int count)
    {
        Result = result;
        Count = count;
    }
}