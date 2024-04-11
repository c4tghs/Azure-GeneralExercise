using AZGE.StockApi.Domain.Products;
using AZGE.StockApi.Shared.Products;

namespace AZGE.StockApi.Infrastructure.Mappers.Products;

public static class ProductMapper
{
    public static Product ToProduct(this ProductDto.Mutate dto)
    {
        Product product = new(
            dto.Id,
            dto.Name
        );

        return product;
    }

    public static ProductDto.Index ToIndexDto(this Product product)
    {
        ProductDto.Index dto = new(
            product.ProductId,
            product.Name
        );

        return dto;
    }
}