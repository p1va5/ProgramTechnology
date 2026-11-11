namespace GuessNumber.Logics;

public interface ILogic
{
    public event EventHandler<RoundEvents>? RoundFinished;
    public ResultRound Round(int secret);
    public int CounterRound(int secret);
}
