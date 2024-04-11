namespace AZGE.StockApi.Shared.Products;

public static class ProductDto
{
    public sealed record Index(
        int Id,
        string Name
    );

    public sealed record Mutate(
        int Id,
        string Name
    );
}