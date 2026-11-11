using GuessNumber.Statistics;
using System.Text.Json;

namespace GuessNumber.Save;

public class StatisticRepository : IRepositoryStatistic
{
    private readonly string _path;
    public StatisticRepository(string path)
    {
        _path = path;
    }
    public StatisticDto Load()
    {
        if (!File.Exists(_path)) return new StatisticDto(0,0,0,0);
        string json = File.ReadAllText(_path);
        return JsonSerializer.Deserialize<StatisticDto>(json);
    }

    public void Save(StatisticDto statistic)
    {
        string json = JsonSerializer.Serialize(statistic);
        File.WriteAllText(_path, json); 
    }
}
