namespace Store.Inventory.Repositories.Interfaces;

public interface IProductRepository
{
    Task<Product> AddProduct(Product model);
    Task<Product> GetProductById(int id);
    Task<int> GetProductsByStatus(int statusId);
}