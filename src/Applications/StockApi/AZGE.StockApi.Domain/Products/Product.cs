namespace AZGE.StockApi.Domain.Products;

public sealed class Product
{
    public int Id { get; init; }
    public int ProductId { get; init; }
    public string Name { get; private set; }

    public Product(int productId, string name)
    {
        ProductId = productId;
        Name = name;
    }

    public void Update(string name)
    {
        UpdateName(name);
    }

    private void UpdateName(string name) 
    {
        Name = name;
    }
}