namespace BarDrinks;
public abstract class Cocktail
{
    private int _id;
    public string Name { get; set; }
    public int Volume { get; set; }
    public AlcoholLevel Alcohol { get; set; } = AlcoholLevel.None;
    public double VolumeInOz => Volume / 30.0;
    public Cocktail(int id, string name, int volume)
    {
        _id = id;
        Name= name;
        Volume = volume;
    }
    public Cocktail(string name) : this(0, name, 0)
    {

    }
    public abstract void Prepare();
}
