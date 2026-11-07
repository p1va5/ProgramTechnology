namespace GuessNumber.Logics;

public interface ILogic
{
    public bool Round(int secret);
    public int CounterRound(int secret);
}
