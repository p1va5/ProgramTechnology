namespace GuessNumber.Core.Setting;
public sealed record Settings(string Level, int Min, int Max)
{
    public static Settings Easy => new("Easy", 1, 50);
    public static Settings Medium => new("Medium", 1, 100);
    public static Settings Hard => new("Hard", 1, 1000);
}
