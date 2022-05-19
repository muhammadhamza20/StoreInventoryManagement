namespace Store.Inventory.Domain.Models;

[Table("Product")]
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string BarCode { get; set; }
    public string Description { get; set; }
    public double Weight { get; set; }
    public int StatusId { get; set; }
    public bool IsActive { get; set; }

    [StringLength(50)]
    public string CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    [StringLength(50)]
    public string UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }
    public virtual InventoryStatus InventoryStatus { get; set; }
    public virtual ICollection<ProductCategory> ProductCategories { get; set; }
}
