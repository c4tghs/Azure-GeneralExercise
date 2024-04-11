using AZGE.ProductApi.Domain.Products;
using AZGE.ProductApi.Shared.Products;

namespace AZGE.ProductApi.Infrastructure.Mappers;

public static class ProductMapper
{
    public static Product ToProduct(this ProductDto.Mutate dto)
    {
        Product product = new(
            dto.Name,
            dto.ImageUrl,
            dto.Price
        );

        return product;
    }

    public static ProductDto.Index ToIndexDto(this Product product)
    {
        ProductDto.Index dto = new(
            product.Id,
            product.Name,
            product.ImageUrl,
            product.Price
        );

        return dto;
    }
}
