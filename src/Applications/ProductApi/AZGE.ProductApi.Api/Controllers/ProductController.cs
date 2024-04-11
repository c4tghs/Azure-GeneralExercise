using AZGE.ProductApi.Domain.Products;
using AZGE.ProductApi.Infrastructure.Mappers;
using AZGE.ProductApi.Services.Products;
using AZGE.ProductApi.Shared.Products;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<int> CreateAsync([FromBody] ProductDto.Mutate dto, CancellationToken cancellationToken)
    {
        Product product = dto
            .ToProduct();

        int id = await _service
            .CreateAsync(
                product,
                cancellationToken
            );

        return id;
    }

    [HttpGet]
    public async Task<List<ProductDto.Index>> GetAllAsync(CancellationToken cancellationToken)
    {
        List<Product> products = await _service
            .GetAllAsync(
                cancellationToken
            );

        List<ProductDto.Index> dtos = products
            .Select(x =>
                x.ToIndexDto()
            )
            .ToList();

        return dtos;
    }

    [HttpGet("{id}")]
    public async Task<ProductDto.Index> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        Product product = await _service
            .GetByIdAsync(
                id,
                cancellationToken
            );

        ProductDto.Index dto = product
            .ToIndexDto();

        return dto;
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