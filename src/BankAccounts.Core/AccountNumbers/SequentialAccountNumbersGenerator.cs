namespace BankAccounts.Core.AccountNumbers;
//последовательная нумерация. Можно заменить на GUI или другую стратегию(SRP)
public sealed class SequentialAccountNumbersGenerator : IAccountNumbersGenerator
{
    private int _seed;
    public SequentialAccountNumbersGenerator(int seed=1234567890) =>_seed = seed;
    public string Next()
    {
        return(_seed++).ToString();
    }
}
