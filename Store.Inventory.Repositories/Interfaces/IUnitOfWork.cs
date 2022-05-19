namespace Store.Inventory.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ICategoryRepository CategoryRepository { get; }

    IProductRepository ProductRepository { get; }

    IInventoryStatusRepository InventoryStatusRepository { get; }

    void DiscardChanges();

    Task<bool> SaveChangesAsync(bool overwriteDbChangesInCaseOfConcurrentUpdates = true);
}