global using System.Reflection;

namespace Store.Inventory.Repositories.RepositoryImpl;

public class UnitOfWork : IUnitOfWork
{
    private ICategoryRepository _categoryRepository;

    private IProductRepository _productRepository;

    private IInventoryStatusRepository _inventoryStatusRepository;

    private readonly InventoryStoreContext _context;

    public UnitOfWork(InventoryStoreContext context)
    {
        _context = context;
    }

    public IProductRepository ProductRepository
    {
        get
        {
            if (_productRepository == null)
            {
                _productRepository = new ProductRepository(_context);
            }

            return _productRepository;
        }
    }

    public ICategoryRepository CategoryRepository
    {
        get
        {
            if (_categoryRepository == null)
            {
                _categoryRepository = new CategoryRepository(_context);
            }

            return _categoryRepository;
        }
    }

    public IInventoryStatusRepository InventoryStatusRepository
    {
        get
        {
            if (_inventoryStatusRepository == null)
            {
                _inventoryStatusRepository = new InventoryStatusRepository(_context);
            }

            return _inventoryStatusRepository;
        }
    }

    public void DiscardChanges()
    {
        foreach (var Entry in _context.ChangeTracker.Entries())
        {
            Entry.State = EntityState.Unchanged;
        }
    }

    public async Task<bool> SaveChangesAsync(bool overwriteDbChangesInCaseOfConcurrentUpdates = true)
    {
        bool saveFailed;
        do
        {
            saveFailed = false;

            try
            {
                int count = await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                saveFailed = true;

                if (overwriteDbChangesInCaseOfConcurrentUpdates)
                {
                    foreach (var Entry in ex.Entries)
                    {
                        foreach (var property in Entry.Entity.GetType().GetTypeInfo().DeclaredProperties)
                        {
                            //var originalValue = Entry.Property(property.Name).OriginalValue;
                            var currentValue = Entry.Property(property.Name).CurrentValue;
                            Entry.Property(property.Name).OriginalValue = currentValue;
                        }
                    }
                }
                else
                {
                    foreach (var Entry in ex.Entries)
                    {
                        foreach (var property in Entry.Entity.GetType().GetTypeInfo().DeclaredProperties)
                        {
                            var originalValue = Entry.Property(property.Name).OriginalValue;
                            //var currentValue = Entry.Property(property.Name).CurrentValue;
                            Entry.Property(property.Name).CurrentValue = originalValue;
                        }
                    }
                }
            }
        } while (saveFailed);
        return await Task.FromResult(!saveFailed);
    }

    #region IDisposable Support
    private bool disposedValue = false; // To detect redundant calls

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects).
            }

            // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
            // TODO: set large fields to null.

            disposedValue = true;
        }
    }

    // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
    // ~UnitOfWork()
    // {
    //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
    //   Dispose(false);
    // }

    // This code added to correctly implement the disposable pattern.
    public void Dispose()
    {
        // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        Dispose(true);
        // TODO: uncomment the following line if the finalizer is overridden above.
        // GC.SuppressFinalize(this);
    }
    #endregion
}