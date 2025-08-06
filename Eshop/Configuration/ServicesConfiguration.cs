using Contracts.Repository;
using Contracts.Services;
using Entities;
using Microsoft.AspNetCore.Identity;
using Repository;
using Services;

namespace Eshop.Configuration;

public static class ServicesConfiguration
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPasswordHasher<Account>, PasswordHasher<Account>>();

        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IAccountRepository, AccountRepository>();
    }
}
