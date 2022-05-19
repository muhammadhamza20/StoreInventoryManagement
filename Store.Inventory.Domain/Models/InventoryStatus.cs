namespace Store.Inventory.Domain.Models;

[Table("InventoryStatus")]
public class InventoryStatus
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
}

