using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Inventory.Domain.Models;

[Table("ProductCategory")]
public class ProductCategory
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int CategoryId { get; set; }

    public bool IsActive { get; set; }

    [StringLength(50)]
    public string CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    [StringLength(50)]
    public string UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual Product Product { get; set; }
    public virtual Category Category { get; set; }
}
