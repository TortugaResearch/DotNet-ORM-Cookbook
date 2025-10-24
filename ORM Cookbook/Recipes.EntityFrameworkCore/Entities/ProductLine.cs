using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Recipes.EntityFrameworkCore.Entities;

[Table("ProductLine", Schema = "Production")]
[Index(nameof(ProductLineName), Name = "UX_ProductLine_ProductLineName", IsUnique = true)]
public partial class ProductLine
{
    public ProductLine()
    {
        Products = new HashSet<Product>();
    }

    [Key]
    public int ProductLineKey { get; set; }

    [Required]
    [StringLength(50)]
    public string ProductLineName { get; set; }

    [InverseProperty(nameof(Product.ProductLineKeyNavigation))]
    public virtual ICollection<Product> Products { get; set; }
}