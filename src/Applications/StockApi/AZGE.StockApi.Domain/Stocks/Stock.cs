using AZGE.StockApi.Domain.Products;

namespace AZGE.StockApi.Domain.Stock;

public sealed class Stock
{
    public int Id { get; init; }
    public int ProductId { get; init; }
    public Product Product { get; } = default!;
    public int Quantity { get; private set; }

    public Stock(int productId) : this(productId, 0) { }

    public Stock (int productId, int quantity)
    {
        ProductId = productId;
        Quantity = quantity;
    }

    public void ChangeStock(int quantity)
    {
        if (quantity > 0)
        {
            AddStock(quantity);
        }
        else
        {
            RemoveStock(quantity);
        }
    }

    private void AddStock(int quantity)
    {
        Quantity = Quantity + quantity;
    }

    private void RemoveStock(int quantity)
    {
        Quantity = Quantity - quantity;
    }
}