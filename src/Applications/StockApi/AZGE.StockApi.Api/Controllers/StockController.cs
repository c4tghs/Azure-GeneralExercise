using AZGE.StockApi.Domain.Stock;
using AZGE.StockApi.Infrastructure.Mappers.Stocks;
using AZGE.StockApi.Services.Products;
using AZGE.StockApi.Services.Stocks;
using AZGE.StockApi.Shared.Stock;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace AZGE.StockApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StockController
{
    private readonly StockService _service;

    public StockController(StockService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<int> CreateAsync([FromBody] StockDto.Mutate dto, CancellationToken cancellationToken)
    {
        Stock stock = dto
            .ToStock();

        int id = await _service
            .CreateAsync(
                stock,
                cancellationToken
            );

        return id;
    }

    [HttpGet]
    public async Task<List<StockDto.Index>> GetAllAsync(CancellationToken cancellationToken)
    {
        List<Stock> stock = await _service
            .GetAllAsync(
                cancellationToken
            );

        List<StockDto.Index> dtos = stock
            .Select(x => 
                x.ToIndexDto()
            )
            .ToList();

        return dtos;
    }

    [HttpGet("{id}")]
    public async Task<StockDto.Index> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        Stock stock = await _service
            .GetByIdAsync(
                id,
                cancellationToken
            );

        StockDto.Index dto = stock
            .ToIndexDto();

        return dto;
    }

    [HttpGet("product/{productId}")]
    public async Task<StockDto.Index> GetByProductIdAsync(int productId, CancellationToken cancellationToken)
    {
        Stock stock = await _service
            .GetByProductIdAsync(
                productId,
                cancellationToken
            );

        StockDto.Index dto = stock
            .ToIndexDto();

        return dto;
    }

    [HttpGet("product/{productId}/change")]
    public async Task ChangeStockAsync([FromBody] StockDto.ChangeStock dto, int productId, CancellationToken cancellationToken)
    {
        await _service
            .ChangeStockAsync(
                productId,
                dto.Quantity,
                cancellationToken
            );
    }
}
