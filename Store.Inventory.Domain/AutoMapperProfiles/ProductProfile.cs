global using AutoMapper;

namespace Store.Inventory.Domain.AutoMapperProfiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductDTO, Product>().ReverseMap();
    }
}