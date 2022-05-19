namespace Store.Inventory.Repositories.Interfaces;

public interface IInventoryStatusRepository
{
    Task<List<InventoryStatus>> GetAllInventoryStatuses();

}
