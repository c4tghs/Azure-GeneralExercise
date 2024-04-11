namespace AZGE.SalesApi.Domain.Products;

public sealed class Product
{
    public int Id { get; init; }
    public string Name { get; init; }

    public Product(string name)
    {
        Name = name;
    }
}