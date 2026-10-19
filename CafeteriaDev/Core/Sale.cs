namespace CafeteriaDev.Core;

public sealed record Sale(
    Guid Id,
    DateTime CreatedAt,
    string CoffeeName,
    decimal UnitPrice,
    int Quantity)
{
    public decimal Total => UnitPrice * Quantity;
}
