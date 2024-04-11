using AZGE.StockApi.Domain.Products;
using AZGE.StockApi.Services.Products;
using AZGE.StockApi.Shared.Products;
using AZGE.StockApi.Infrastructure.Mappers.Products;
using Microsoft.AspNetCore.Mvc;

namespace AZGE.StockApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductService _service;

    public ProductController(ProductService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task CreateAsync([FromBody] ProductDto.Mutate dto, CancellationToken cancellationToken)
    {
        Product product = dto
            .ToProduct();
        
        await _service
            .CreateAsync(
                product,
                cancellationToken
            );
    }

    [HttpPut("{id}")]
    public async Task UpdateByIdAsync([FromBody] ProductDto.Mutate dto, int id, CancellationToken cancellationToken)
    {
        Product product = dto
            .ToProduct();

        await _service
            .UpdateByIdAsync(
                id,
                product,
                cancellationToken
            );
    }
}
