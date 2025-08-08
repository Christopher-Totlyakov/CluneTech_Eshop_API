using Contracts.Repository;
using Contracts.Services;
using Entities;
using Microsoft.AspNetCore.Identity;
using Repository;
using Services;
using System.ComponentModel.Design;

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
        services.AddScoped<ISaleService, SaleService>();
        services.AddScoped<ISaleRepository, SaleRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
    }
}
