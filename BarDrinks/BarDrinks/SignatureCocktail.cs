namespace BarDrinks;
internal class SignatureCocktail : Cocktail, IMixable
{
    public string ChefName { get; set; }
    public SignatureCocktail(int id, string name, int volume, string chefName) : base(id, name, volume)
    {
        ChefName = chefName;
    }
    public bool IsAuthorial => !string.IsNullOrWhiteSpace(ChefName);
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
        return $"[SignatureCocktail] {Name}, {Volume} ml, alcohol: {Alcohol}, Chef name: {ChefName}\n volume in oz: {VolumeInOz:0.0#}";
    }
}
