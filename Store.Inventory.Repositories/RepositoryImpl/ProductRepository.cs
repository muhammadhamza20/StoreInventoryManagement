namespace Store.Inventory.Repositories.RepositoryImpl;

public class ProductRepository : IProductRepository
{
    private readonly InventoryStoreContext _context;

    public ProductRepository(InventoryStoreContext context)
    {
        _context = context;
    }

    public async Task<Product> AddProduct(Product model)
    {
        var saved = _context.Products.Add(model);
        return await Task.FromResult(saved.Entity);
    }

    public async Task<int> GetProductsByStatus(int statusId)
    {
        return await _context.Products.CountAsync(x => x.StatusId == statusId);
    }

    public async Task<Product> GetProductById(int id)
    {
        return await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
    }
}