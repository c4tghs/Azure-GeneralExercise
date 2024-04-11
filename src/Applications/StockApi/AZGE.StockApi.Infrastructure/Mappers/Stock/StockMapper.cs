using AZGE.StockApi.Domain.Stock;
using AZGE.StockApi.Infrastructure.Mappers.Products;
using AZGE.StockApi.Shared.Stock;

namespace AZGE.StockApi.Infrastructure.Mappers.Stocks;

public static class StockMapper
{
    public static Stock ToStock(this StockDto.Mutate dto)
    {
        Stock stock;

        if (dto.Quantity is null)
        {
            stock = new(
                dto.ProductId
            );
        }
        else
        {
            stock = new(
                dto.ProductId,
                (int)dto.Quantity
            );
        }

        return stock;
    }

    public static StockDto.Index ToIndexDto(this Stock stock)
    {
        StockDto.Index dto = new(
            stock.Id,
            stock.Product.ToIndexDto(),
            stock.Quantity
        );

        return dto;
    }
}