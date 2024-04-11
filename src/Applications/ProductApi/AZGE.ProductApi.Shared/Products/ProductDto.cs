namespace AZGE.ProductApi.Shared.Products;

public static class ProductDto
{
    public sealed record Index(
        int Id,
        string Name,
        string? ImageUrl,
        decimal Price
    );

    public sealed record Mutate(
        string Name,
        string? ImageUrl,
        decimal Price
    );
}