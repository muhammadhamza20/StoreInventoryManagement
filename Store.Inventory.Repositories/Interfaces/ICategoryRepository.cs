namespace Store.Inventory.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<List<Category>> GetAllCategories();
    Task<Category> AddCategory(Category model);
    Task<bool> CategoryExist(string name);
}