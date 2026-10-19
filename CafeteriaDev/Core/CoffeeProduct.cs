using System.Globalization;

namespace CafeteriaDev.Core;

public sealed record CoffeeProduct(string Name, decimal Price)
{
    private static readonly CultureInfo BrazilianCulture =
        CultureInfo.GetCultureInfo("pt-BR");

    public override string ToString()
    {
        return $"{Name} — {Price.ToString("C", BrazilianCulture)}";
    }
}
