
namespace Inventory.Store.Services.Interfaces;

public interface IProductService
{
    Task<List<ProductCountDTO>> GetProductCountsByStatuses();
    Task<bool> UpdateStatus(int productId, string status);
    Task<bool> MarkProductAsSold(int productId);
}