global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;

namespace Store.Inventory.Domain.Config;

public static class RegisterDomainServices
{
    private static IServiceCollection _services;
    private static IConfiguration _configuration;

    public static void RegisterComponents(IServiceCollection services, IConfiguration configuration)
    {
        _services = services;
        _configuration = configuration;

        _services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        //autoMapper.ConfigurationProvider.AssertConfigurationIsValid();
    }
}