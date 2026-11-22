using GuessNumber.Core.Secret;

namespace GuessNumber.Core.Game;

public class Game
{
    private readonly ISecret _secret;
    private readonly int _number;
    public event EventHandler<RoundCheckEventArgs>? Check;
    public Game(ISecret secret)
    { 
        _secret = secret;
        _number = _secret.GetNumber(1, 100);
    }
    public bool Round(int input)
    {
        RoundResult result = RoundResult.Correct;
        if(_number < input) result = RoundResult.Lower;
        if (_number > input) result = RoundResult.High;
        Check?.Invoke(this, new RoundCheckEventArgs(result));
        if(result == RoundResult.Correct) return true;
        return false;
    }
}
