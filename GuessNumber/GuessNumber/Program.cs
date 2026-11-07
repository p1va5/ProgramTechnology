using GuessNumber.Games;
using GuessNumber.Logics;
using GuessNumber.Secret;

namespace GuessNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ILogic logic = new GameLogic();
            ISecretNum secret = new RandomNubmer();
            IGame game = new Game(secret, logic);
            game.Play();
        }
    }
}
