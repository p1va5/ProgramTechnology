namespace GuessNumber;

public class GameLogic : ILogic
{
    public bool Round(int secret)
    {
        while (true)
        {
            Console.WriteLine("Введите число [1,100]");
            int input = Convert.ToInt32(Console.ReadLine());
            if (secret < input)
            {
                Console.WriteLine("Меньше");
            }
            if (secret > input)
            {
                Console.WriteLine("Больше");
            }
            if(secret == input) return true;
        }
    }
}
