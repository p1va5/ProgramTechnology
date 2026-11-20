namespace GuessNumber.Core.Secret;

public class RandomNumber : ISecret
{
    private readonly Random _random = new Random();
    public int GetNumber(int min, int max)
    {
        return _random.Next(min, max + 1);
    }
}
