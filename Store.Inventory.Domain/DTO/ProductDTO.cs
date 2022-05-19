namespace Store.Inventory.Domain.DTO;

public class ProductDTO
{
    public string Name { get; set; }
    public string BarCode { get; set; }
    public string Description { get; set; }
    public double Weight { get; set; }
    public string Status { get; set; }
}
