namespace Store.Inventory.Domain.DTO;

public class CategoryDTO
{
    public string Name { get; set; }
    public bool IsActive { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }
    public virtual ICollection<ProductCategory> ProductCategories { get; set; }
}
