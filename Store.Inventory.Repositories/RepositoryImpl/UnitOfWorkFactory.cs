global using Microsoft.Extensions.DependencyInjection;
global using Store.Inventory.Repositories.Interfaces;

namespace Store.Inventory.Repositories.RepositoryImpl;

public class UnitOfWorkFactory : IUnitOfWorkFactory
{
    private readonly IServiceProvider _serviceProvider;

    public UnitOfWorkFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IUnitOfWork CreateUnitOfWork()
    {
        return _serviceProvider.GetRequiredService<IUnitOfWork>();
    }
}