using GuessNumber.Core.Secret;

namespace GuessNumber.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ISecret secret = new RandomNumber(); 
            System.Console.WriteLine(secret.GetNumber(1,100));
        }
    }
}
