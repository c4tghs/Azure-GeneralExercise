using AZGE.SalesApi.Domain.Products;

namespace AZGE.SalesApi.Domain.Sales;

public sealed class Sale 
{
    public int Id { get; init; }
    public DateTime DateOfSale { get; init; }
    public int ProductId { get; init; }
    public Product Product { get; } = default!;

    public Sale(int productId)
    {
        DateOfSale = DateTime.UtcNow;
        ProductId = productId;
    }
}