global using AutoMapper;
global using Inventory.Store.Services.Interfaces;
global using Store.Inventory.Domain.DTO;
global using Store.Inventory.Repositories.Interfaces;

namespace Store.Inventory.Services.ServicesImpl;

public class ProductService : IProductService
{
    private IConfiguration _configuration { get; }
    private readonly IMapper _autoMapper;
    private readonly IUnitOfWorkFactory _unitOfWorkFactory;

    public ProductService(IConfiguration configuration,
        IUnitOfWorkFactory unitOfWorkFactory,
        IMapper autoMapper)
    {
        _configuration = configuration;
        _unitOfWorkFactory = unitOfWorkFactory;
        _autoMapper = autoMapper;
    }


    public async Task<List<ProductCountDTO>> GetProductCountsByStatuses()
    {
        using var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork();
        var allInventoryStatuses = await unitOfWork.InventoryStatusRepository.GetAllInventoryStatuses();

        if (allInventoryStatuses == null)
            return null;

        var response = new List<ProductCountDTO>();
        foreach (var status in allInventoryStatuses)
        {
            var productsCount = await unitOfWork.ProductRepository.GetProductsByStatus(status.Id);
            response.Add(new ProductCountDTO { InventoryStatus = status.Name, NumberOfProducts = productsCount });
        }

        return response;
    }

    public async Task<bool> UpdateStatus(int productId, string status)
    {
        if (string.IsNullOrWhiteSpace(status) || (!string.IsNullOrWhiteSpace(status) && !Enum.GetNames(typeof(Status)).Contains(status)))
            return false;

        using var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork();
        var product = await unitOfWork.ProductRepository.GetProductById(productId);

        if (product == null)
            return false;

        product.StatusId = (int)Enum.Parse(typeof(Status), status);
        return await unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> MarkProductAsSold(int productId)
    {
        using var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork();
        var product = await unitOfWork.ProductRepository.GetProductById(productId);

        if (product == null)
            return false;

        product.StatusId = (int)Status.Sold;
        return await unitOfWork.SaveChangesAsync();
    }
}