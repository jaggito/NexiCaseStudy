using Microsoft.Extensions.DependencyInjection;
using ProductService.Core.Interfaces;
using ProductService.Infrastructure.Repositories;

namespace ProductService.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddProductServiceDependencies(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, Core.Services.ProductService>();
        return services;
    }
}
