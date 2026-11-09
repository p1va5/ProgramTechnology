using GuessNumber.Output;

namespace GuessNumber.Logics;

public interface ILogic
{
    public ResultRound Round(int secret);
    public int CounterRound(int secret);
}
