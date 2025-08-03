using Contracts.Repository.ProductManagement;
using Repository.ProductManagement;

namespace Eshop.Configuration;

public static class ServicesConfiguration
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<RepositoryContext, RepositoryContext>();

        services.AddScoped<IProductRepository, ProductRepository>();
    }
}
