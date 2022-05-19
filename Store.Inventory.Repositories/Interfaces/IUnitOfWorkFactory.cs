namespace Store.Inventory.Repositories.Interfaces;

public interface IUnitOfWorkFactory
{
    IUnitOfWork CreateUnitOfWork();
}