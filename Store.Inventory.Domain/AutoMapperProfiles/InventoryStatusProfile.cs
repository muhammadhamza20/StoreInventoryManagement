namespace Store.Inventory.Domain.AutoMapperProfiles;

public class InventoryStatusProfile : Profile
{
    public InventoryStatusProfile()
    {
        CreateMap<InventoryStatusDTO, InventoryStatus>().ReverseMap();
    }
}
