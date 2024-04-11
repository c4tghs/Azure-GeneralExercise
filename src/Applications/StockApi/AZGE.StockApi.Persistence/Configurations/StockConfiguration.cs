using AZGE.StockApi.Domain.Stock;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AZGE.StockApi.Persistence.Configurations;

internal class StockConfiguration : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.ToTable(typeof(Stock).Name);

        builder
            .HasOne(x => x.Product)
            .WithOne();
    }
}
