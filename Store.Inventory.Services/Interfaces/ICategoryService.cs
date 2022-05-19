namespace Inventory.Store.Services.Interfaces;

public interface ICategoryService
{
    Task<string> AddCategory(AddCategoryDTO categoryDTO);
    Task<List<CategoryDTO>> GetAllCategories();

}