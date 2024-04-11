using AZGE.ProductApi.Domain.Products;
using AZGE.ProductApi.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AZGE.ProductApi.Services.Products;

public class ProductService
{
    private readonly ProductDbContext _context;

    public ProductService(ProductDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateAsync(Product product, CancellationToken cancellationToken)
    {
        _context
            .Products
            .Add(product);

        await _context.SaveChangesAsync(cancellationToken);

        return product.Id;
    }

    public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context
            .Products
            .ToListAsync(cancellationToken);
    }

    public async Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        Product? product = await _context
            .Products
            .FirstOrDefaultAsync(x => 
                x.Id == id,
                cancellationToken
            );

        if (product is null)
            throw new Exception("Product not found");

        return product;
    }

    public async Task UpdateByIdAsync(int id, Product product, CancellationToken cancellationToken)
    {
        Product productToUpdate = await GetByIdAsync(id, cancellationToken);

        productToUpdate
            .Update(
                product.Name,
                product.ImageUrl,
                product.Price
            );

        await _context
            .SaveChangesAsync(cancellationToken);
    }
}
