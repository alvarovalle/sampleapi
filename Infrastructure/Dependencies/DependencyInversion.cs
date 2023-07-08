using Interfaces.Persistence.Product;
using Interfaces.UserCases;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Dependencies;

public class DependencyInversion
{
    
    public static void Register(Microsoft.Extensions.DependencyInjection.IServiceCollection services)
    { 
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductManager, ProductManager>();
    }
}
