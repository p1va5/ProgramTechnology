namespace Class;

internal class CsvRepository
{
    private string _basePath;
    public CsvRepository(string basePath) { _basePath = basePath; }

    public List<Drink> GetDrinks()
    {
        List<Drink> result = new List<Drink>();
        string[] lines = File.ReadAllLines(Path.Combine(_basePath, "drinks.csv"));
        if (lines.Length < 2) return result;
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(';');
            if (parts.Length < 6) continue;
            var Id = int.Parse(parts[0]);
            var Name = parts[1];
            var ShiftId = int.Parse(parts[2]);
            var BaristaId = int.Parse(parts[3]);
            var Price = decimal.Parse(parts[4]);
            var Volume = int.Parse(parts[5]);
            Drink b = new Drink(Id, Name, ShiftId, BaristaId, Price, Volume);
            result.Add(b);
        }
        return result;
    }
    public List<Barista> GetBaristas()
    {
        List<Barista> result = new List<Barista>();
        string[] lines = File.ReadAllLines(Path.Combine(_basePath, "baristas.csv"));
        if (lines.Length < 2) return result;
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(';');
            if (parts.Length < 4) continue;
            var Id = int.Parse(parts[0]);
            var FullName = parts[1];
            var Experience = int.Parse(parts[2]);
            var Rating = double.Parse(parts[3]);
            Barista b = new Barista(Id, FullName, Experience, Rating);
            result.Add(b);
        }
        return result;
    }
    public List<Shift> GetShifts()
    {
        List<Shift> result = new List<Shift>();
        string[] lines = File.ReadAllLines(Path.Combine(_basePath, "shifts.csv"));
        if (lines.Length < 2) return result;
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(';');
            if (parts.Length < 3) continue;
            var Id = int.Parse(parts[0]);
            var Time = parts[1];
            var Date = DateTime.Parse(parts[2]);
            Shift b = new Shift(Id, Time, Date);
            result.Add(b);
        }
        return result;
    }
}