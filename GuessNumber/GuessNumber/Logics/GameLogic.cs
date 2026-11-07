namespace GuessNumber.Logics;

public class GameLogic : ILogic
{
    public bool Round(int secret)
    {
        Console.WriteLine("Введите число [1,100]");
        Console.WriteLine(secret);
        int input = Convert.ToInt32(Console.ReadLine());
        if (secret < input)
        {
            Console.WriteLine("Меньше");
            return false;
        }
        if (secret > input)
        {
            Console.WriteLine("Больше");
            return false;
        }
        return true;
    }
    public int CounterRound(int secret)
    {
        int CountRound = 0;
        while (true)
        {
            CountRound++;
            if (Round(secret)) return CountRound;
        }
    }
}
