using AZGE.StockApi.Shared.Products;

namespace AZGE.StockApi.Shared.Stock;

public static class StockDto
{
    public sealed record Index(int Id, ProductDto.Index Product, int Quantity);

    public sealed record Mutate(int ProductId, int? Quantity);

    public sealed record ChangeStock(int Quantity);
}
