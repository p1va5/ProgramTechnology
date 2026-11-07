namespace GuessNumber.Input;

public class InputConsole : IInput
{
    public bool AskAgain()
    {
        Console.WriteLine("Ещё раз?(y)");
        string answer = Console.ReadLine();
        if (answer == "y") return true;
        return false;
    }
    public int InputNumber(int min, int max)
    {
        int userNumber;
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"Выбери число [{min},{max}]");
            string input = Console.ReadLine();

            if (int.TryParse(input, out userNumber) && userNumber >= min && userNumber <= 100)
            {
                return userNumber;
            }
            Console.WriteLine("Некорректный ввод");
        }
        throw new Exception("Некорректный ввод");
    }
}
