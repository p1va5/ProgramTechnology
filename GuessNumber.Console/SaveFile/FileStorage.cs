using GuessNumber.Core.Player;
using System.Text.Json;

namespace GuessNumber.Console.SaveFile;

public class FileStorage : IFile
{
    private readonly string _path;
    public FileStorage(string path)
    {
        _path = path;
    }

    public Dictionary<string, User> LoadUsers()
    {
        if (!File.Exists(_path)) return new Dictionary<string, User>();
        string json = File.ReadAllText(_path);
        return JsonSerializer.Deserialize<Dictionary<string, User>>(json) ?? throw new InvalidDataException("Не удалось прочитать профили игроков.");
    }

    public void SaveUsers(Dictionary<string, User> users)
    {
        string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_path, json);
    }
}
