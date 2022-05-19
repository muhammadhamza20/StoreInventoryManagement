global using Store.Inventory.Domain.Models;
global using Store.Inventory.Domain.DTO;

namespace Store.Inventory.Domain.AutoMapperProfiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CategoryDTO, Category>().ReverseMap(); 
        CreateMap<AddCategoryDTO, Category>().ReverseMap();

    }
}
