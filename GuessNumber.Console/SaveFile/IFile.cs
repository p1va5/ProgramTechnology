
using GuessNumber.Core.Player;

namespace GuessNumber.Console.SaveFile;

public interface IFile
{
    Dictionary<string, User> LoadUsers();
    void SaveUsers(Dictionary<string, User> users);
}
