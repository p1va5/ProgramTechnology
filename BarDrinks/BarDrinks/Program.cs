namespace BarDrinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Cocktail> cocktails = new List<Cocktail>
            {
            new Mocktail(1, "Virgin Mojito", 300, "lime"),
            new ClassicCocktail(2, "Martini", 100, "gin"),
            new SignatureCocktail(3, "Alyosha", 200, "Alyosha")
            };
            foreach (var cocktail in cocktails)
            { 
                Console.WriteLine(cocktail.ToString());
                cocktail.Prepare();
                if (cocktail is IMixable mixable) mixable.Mix("lime");
                else Console.WriteLine($"{cocktail.Name} cannot be mixed.");
                Console.WriteLine("----------------------------------------");
            }
        }
    }
}
