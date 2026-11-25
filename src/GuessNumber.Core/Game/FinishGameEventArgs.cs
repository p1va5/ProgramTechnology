using GuessNumber.Core.Setting;

namespace GuessNumber.Core.Game;

public class FinishGameEventArgs : EventArgs
{
    public string Level { get; }
    public int Count { get; }
    public FinishGameEventArgs(string level, int count)
    {
        Level = level;
        Count = count;
    }
}
