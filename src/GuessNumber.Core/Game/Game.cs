using GuessNumber.Core.Secret;
using GuessNumber.Core.Setting;

namespace GuessNumber.Core.Game;

public class Game
{
    private readonly ISecret _secret;
    private readonly Settings _settings;
    private readonly int _number;
    public event EventHandler<RoundCheckEventArgs>? Check;
    public Game(ISecret secret, Settings settings)
    { 
        _secret = secret;
        _settings = settings;
        _number = _secret.GetNumber(_settings.Min, _settings.Max);
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
