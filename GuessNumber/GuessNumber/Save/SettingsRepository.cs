using GuessNumber.GameSettings;
using System.Text.Json;

namespace GuessNumber.Save;

public class SettingsRepository : IRepositorySettings
{
    private readonly string _path;
    public SettingsRepository(string path)
    {
        _path = path;
    }

    public bool FileExists()
    {
        return File.Exists(_path);
    }

    public Setting Load()
    {
        if (!File.Exists(_path)) return new Setting(Difficulty.Medium, 1, 100);
        string json = File.ReadAllText(_path);
        return JsonSerializer.Deserialize<Setting>(json);
    }

    public void Save(Setting setting)
    {
        string json = JsonSerializer.Serialize(setting);
        File.WriteAllText(_path, json);
    }
}
