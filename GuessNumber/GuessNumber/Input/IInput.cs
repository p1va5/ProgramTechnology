namespace GuessNumber.Input;

public interface IInput
{
    public int InputNumber(int min, int max);
    public bool AskAgain();
}
