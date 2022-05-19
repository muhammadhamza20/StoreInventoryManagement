global using Store.Inventory.Domain.Enum;
global using Store.Inventory.Domain.Models;

namespace Store.Inventory.Services.ServicesImpl;

public class CategoryService : ICategoryService
{
    private readonly IMapper _autoMapper;
    private readonly IUnitOfWorkFactory _unitOfWorkFactory;

    public CategoryService(IUnitOfWorkFactory unitOfWorkFactory,
        IMapper autoMapper
        )
    {
        _autoMapper = autoMapper;
        _unitOfWorkFactory = unitOfWorkFactory;
    }

    public async Task<string> AddCategory(AddCategoryDTO categoryDTO)
    {
        using var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork();
        if (await unitOfWork.CategoryRepository.CategoryExist(categoryDTO.Name))
            return "Category already exist.";

        var category = _autoMapper.Map<Category>(categoryDTO);

        category.IsActive = true;
        category.CreatedBy = "System";
        category.CreatedDate = DateTime.Now;
        category.UpdatedBy = "System";
        category.UpdatedDate = DateTime.Now;

        var addedUser = await unitOfWork.CategoryRepository.AddCategory(category);
        await unitOfWork.SaveChangesAsync();

        return ApiResponse.Success.ToString();
    }

    public async Task<List<CategoryDTO>> GetAllCategories()
    {
        using var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork();
        var allCategories = await unitOfWork.CategoryRepository.GetAllCategories();

        if (allCategories == null)
            return null;

        return _autoMapper.Map<List<CategoryDTO>>(allCategories);
    }
}