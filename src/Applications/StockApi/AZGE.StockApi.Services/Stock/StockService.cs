using AZGE.StockApi.Domain.Stock;
using AZGE.StockApi.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AZGE.StockApi.Services.Stocks;

public class StockService
{
    private readonly StockDbContext _context;

    public StockService(StockDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateAsync(Stock stock, CancellationToken cancellationToken)
    {
        _context
            .Stock
            .Add(stock);

        await _context.SaveChangesAsync(cancellationToken);

        return stock.Id;
    }

    public async Task<List<Stock>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context
            .Stock
            .Include(x => x.Product)
            .ToListAsync(cancellationToken);
    }

    public async Task<Stock> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        Stock? stock = await _context
            .Stock
            .Include(x => x.Product)
            .FirstOrDefaultAsync(x =>
                x.Id == id,
                cancellationToken
            );

        if (stock is null)
            throw new Exception("Stock not found");

        return stock;
    }

    public async Task<Stock> GetByProductIdAsync(int productId, CancellationToken cancellationToken)
    {
        Stock? stock = await _context
            .Stock
            .Include(x => x.Product)
            .FirstOrDefaultAsync(x =>
                x.ProductId == productId,
                cancellationToken
            );

        if (stock is null)
            throw new Exception("Stock not found");

        return stock;
    }

    public async Task ChangeStockAsync(int productId, int quantity, CancellationToken cancellationToken)
    {
        Stock stock = await GetByProductIdAsync(productId, cancellationToken);

        stock.ChangeStock(quantity);

        await _context
            .SaveChangesAsync(cancellationToken);
    }
}