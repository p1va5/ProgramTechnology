namespace GuessNumber.Secret;
public class RandomNubmer : ISecretNum
{
    private readonly Random _random = new Random();
    public int GetNumber(int min, int max)
    {
        return _random.Next(min, max + 1);
    }
}
