using AZGE.StockApi.Domain.Products;
using AZGE.StockApi.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AZGE.StockApi.Services.Products;

public class ProductService
{
    private readonly StockDbContext _context;

    public ProductService(StockDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Product product, CancellationToken cancellationToken)
    {
        _context
            .Products
            .Add(product);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateByIdAsync(int id, Product product, CancellationToken cancellationToken)
    {
        Product productToUpdate = await GetByIdAsync(id, cancellationToken);

        productToUpdate
            .Update(
                product.Name
            );

        await _context
            .SaveChangesAsync(cancellationToken);
    }

    private async Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        Product? product = await _context
            .Products
            .FirstOrDefaultAsync(x =>
                x.ProductId == id,
                cancellationToken
            );

        if (product is null)
            throw new Exception("Product not found");

        return product;
    }
}