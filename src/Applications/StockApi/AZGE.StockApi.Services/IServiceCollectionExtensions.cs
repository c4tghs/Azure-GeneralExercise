using AZGE.StockApi.Services.Products;
using Microsoft.Extensions.DependencyInjection;
using AZGE.StockApi.Services.Stocks;

namespace AZGE.StockApi.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddStockServices(this IServiceCollection services)
    {
        services.AddScoped<StockService>();
        services.AddScoped<ProductService>();

        return services;
    }
}