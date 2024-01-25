using ProductAPI.Infrastructure.Repositories.Interfaces;
using ProductAPI.Infrastructure.Repositories;
using ProductAPI.Application.Services.Interfaces;
using ProductAPI.Application.Services;

namespace ProductAPI.Infrastructure.Extensions;

public static class DataExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();

        return services;
    }
}
