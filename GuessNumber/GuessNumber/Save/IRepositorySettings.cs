using GuessNumber.GameSettings;
using GuessNumber.Statistics;

namespace GuessNumber.Save;

public interface IRepositorySettings
{
    public void Save(Setting statistic);
    public Setting Load();
    public bool FileExists();
}
