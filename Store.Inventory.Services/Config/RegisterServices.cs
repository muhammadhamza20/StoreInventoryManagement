global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Store.Inventory.Services.ServicesImpl;

namespace Store.Inventory.Services.Config;

public static class RegisterServices
{
    private static IServiceCollection _services;
    private static IConfiguration _configuration;

    public static void RegisterComponents(IServiceCollection services, IConfiguration configuration)
    {
        _services = services;
        _configuration = configuration;

        //Register all the services here
        _services.AddTransient<ICategoryService, CategoryService>();
        _services.AddTransient<IProductService, ProductService>();
    }
}