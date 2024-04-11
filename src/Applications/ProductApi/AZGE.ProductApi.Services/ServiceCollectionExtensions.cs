using AZGE.ProductApi.Services.Products;
using Microsoft.Extensions.DependencyInjection;

namespace AZGE.ProductApi.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddProductServices(this IServiceCollection services)
    {
        services.AddScoped<ProductService>();

        return services;
    }
}