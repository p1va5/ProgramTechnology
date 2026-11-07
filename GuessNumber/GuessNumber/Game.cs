namespace GuessNumber;

internal class Game : IGame
{
    private readonly ISecretNum _secret;
    private readonly ILogic _logic;
    public Game(ISecretNum secret, ILogic logic)
    {
        _secret = secret;
        _logic= logic;
    }

    public void Play()
    {
        char playAgain;
        do
        {
            int num = _secret.GetNumber(1, 100);
            _logic.Round(num);
            Console.WriteLine("Ещё раз?");
            playAgain = Convert.ToChar(Console.ReadLine());
        } while (playAgain=='y');
    }
}
