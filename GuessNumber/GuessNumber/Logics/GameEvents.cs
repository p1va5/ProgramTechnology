using GuessNumber.Output;

namespace GuessNumber.Logics;

public class RoundEvents
{
    public int Secret { get; }
    public ResultRound Result { get; }
    public int Count { get; }
    public RoundEvents(int secret, ResultRound result, int count)
    {
        Secret = secret;
        Result = result;
        Count = count;
    }
}
public class WinEvents
{
    public int Secret { get; }
    public int Count { get; }
    public WinEvents(int secret, int count)
    {
        Secret = secret;
        Count = count;
    }
}

