namespace GuessNumber.Core.Game;
public sealed class RoundCheckEventArgs : EventArgs
{
    public RoundResult RoundResult { get; }
    public RoundCheckEventArgs(RoundResult roundResult)
    {
        RoundResult = roundResult;
    }
}
