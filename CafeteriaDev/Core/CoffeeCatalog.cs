namespace CafeteriaDev.Core;

public static class CoffeeCatalog
{
    public static IReadOnlyList<CoffeeProduct> Products { get; } =
        Array.AsReadOnly(new CoffeeProduct[]
        {
            new CoffeeProduct("Espresso", 7.50m),
            new CoffeeProduct("Café coado", 6.00m),
            new CoffeeProduct("Cappuccino", 12.00m),
            new CoffeeProduct("Latte", 13.50m),
            new CoffeeProduct("Mocha", 15.00m),
            new CoffeeProduct("Café gelado", 14.00m)
        });
}
