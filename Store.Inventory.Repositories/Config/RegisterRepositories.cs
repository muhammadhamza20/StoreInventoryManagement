global using Inventory.Store.Repositories.Context;
global using Microsoft.Extensions.Configuration;
global using Store.Inventory.Repositories.RepositoryImpl;

namespace Store.Inventory.Repositories.Config;

public static class RegisterRepositories
{
    private static IConfiguration _configuration;
    private static IServiceCollection _services;

    public static void RegisterComponents(IServiceCollection services, IConfiguration configuration)
    {
        _configuration = configuration;
        _services = services;

        _services.AddEntityFrameworkSqlServer()
                .AddDbContext<InventoryStoreContext>(
                    options => options.UseSqlServer(_configuration.GetConnectionString("SQLSERVERDB"), providerOptions => providerOptions.EnableRetryOnFailure())
            );

        //Only register our unitofwork and its factory.
        _services.AddTransient<IUnitOfWorkFactory, UnitOfWorkFactory>();
        _services.AddTransient<IUnitOfWork, UnitOfWork>();
    }
}
