namespace CafeteriaDev.Core;

public sealed class SalesRepository
{
    private readonly List<Sale> _sales = [];

    public IReadOnlyList<Sale> GetAll()
    {
        return _sales.AsReadOnly();
    }

    public void Add(Sale sale)
    {
        ArgumentNullException.ThrowIfNull(sale);

        if (sale.Quantity <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(sale), "The quantity must be greater than zero.");
        }

        if (sale.UnitPrice < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(sale), "The price cannot be negative.");
        }

        _sales.Add(sale);
    }
}
