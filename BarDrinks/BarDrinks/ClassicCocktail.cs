namespace BarDrinks;

internal class ClassicCocktail : Cocktail
{
    public string BaseSpirit {  get; set; }
    public ClassicCocktail(int id, string name, int volume, string baseSpirit) : base(id, name, volume)
    {
        BaseSpirit = baseSpirit;
    }
    public bool IsStrong => Alcohol == AlcoholLevel.High;
    public override void Prepare()
    {
        Console.WriteLine($"{Name} prepared.");
    }
    public override string ToString()
    {
        return $"[ClassicCocktail] {Name}, {Volume} ml, alcohol: {Alcohol}, base: {BaseSpirit}\n volume in oz: {VolumeInOz:0.0#}";
    }
}
