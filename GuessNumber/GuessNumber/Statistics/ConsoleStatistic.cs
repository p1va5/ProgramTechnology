namespace GuessNumber.Statistics;
internal class ConsoleStatistic : IStatistic
{
    private int _min = int.MaxValue;
    private int _max = 0;
    private int _count = 0;
    private int _countGame = 0;
    public void AddStatistic(int counter)
    {
        if (_min == 0 || counter < _min) _min = counter;
        if (counter > _max) _max = counter;
        _count += counter;
        _countGame++;
    }
    public void ShowStatistic()
    {
        if (_countGame == 0) return;
        Console.WriteLine($"min = {_min} max= {_max} avg = {(double)_count / _countGame}");
    }
}
