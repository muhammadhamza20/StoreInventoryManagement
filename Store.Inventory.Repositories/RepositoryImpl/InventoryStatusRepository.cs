namespace Store.Inventory.Repositories.RepositoryImpl;

public class InventoryStatusRepository : IInventoryStatusRepository
{
    private readonly InventoryStoreContext _context;

    public InventoryStatusRepository(InventoryStoreContext context)
    {
        _context = context;
    }
    public async Task<List<InventoryStatus>> GetAllInventoryStatuses()
    {
        return await _context.InventoryStatuses.ToListAsync();
    }
}
