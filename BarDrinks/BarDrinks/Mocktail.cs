namespace BarDrinks;
internal class Mocktail : Cocktail, IMixable
{
    public string MainFlavor { get; set; }
    public Mocktail(int id, string name, int volume, string mainFlavor) : base(id, name, volume)
    {
        MainFlavor = mainFlavor;
    }
    public bool IsFruity => MainFlavor == "fruit" || MainFlavor == "lime" || MainFlavor == "berry" || MainFlavor == "citrus";
    public override void Prepare()
    {
        Console.WriteLine($"{Name} prepared.");
    }
    public void Mix(string ingredient)
    {
        Console.WriteLine($"{Name} mixed with {ingredient}.");
    }
    public override string ToString()
    {
        return $"[Mocktail] {Name}, {Volume} ml, alcohol: {Alcohol}\n volume in oz: {VolumeInOz:0.0#}";
    }

}
