using GuessNumber.Output;

namespace GuessNumber.Logics;

public interface ILogic
{
    public event EventHandler<RoundEvents>? RoundFinished;
    public event EventHandler<WinEvents>? GameWin;
    public ResultRound Round(int secret);
    public int CounterRound(int secret);
}
