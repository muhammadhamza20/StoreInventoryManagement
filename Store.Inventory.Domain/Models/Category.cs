global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Inventory.Domain.Models;

[Table("Category")]
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }

    [StringLength(50)]
    public string CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    [StringLength(50)]
    public string UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }
    public virtual ICollection<ProductCategory> ProductCategories { get; set; }
}
