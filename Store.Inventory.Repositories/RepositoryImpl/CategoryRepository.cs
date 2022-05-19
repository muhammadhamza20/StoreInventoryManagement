namespace Store.Inventory.Repositories.RepositoryImpl;

public class CategoryRepository : ICategoryRepository
{
    private readonly InventoryStoreContext _context;

    public CategoryRepository(InventoryStoreContext context)
    {
        _context = context;
    }

    public async Task<Category> AddCategory(Category model)
    {
        var saved = _context.Categories.Add(model);
        return await Task.FromResult(saved.Entity);
    }

    public async Task<List<Category>> GetAllCategories()
    {
        return await _context.Categories.ToListAsync();
        //return await _context.Categories.Include(x=>x.ProductCategories).ToListAsync();
    }

    public async Task<bool> CategoryExist(string name)
    {
        return await _context.Set<Category>().AnyAsync(x => x.Name.Equals(name));
    }

}