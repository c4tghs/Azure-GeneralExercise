using AZGE.StockApi.Domain.Products;
using AZGE.StockApi.Domain.Stock;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AZGE.StockApi.Persistence;

public class StockDbContext : DbContext
{
    public DbSet<Stock> Stock => Set<Stock>();
    public DbSet<Product> Products => Set<Product>();

    public StockDbContext(DbContextOptions<StockDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.EnableDetailedErrors();
        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
        configurationBuilder.Properties<string>().HaveMaxLength(4_000);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("StockApi");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
