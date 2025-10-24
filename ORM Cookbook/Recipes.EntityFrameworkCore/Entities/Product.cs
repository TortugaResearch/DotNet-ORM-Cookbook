using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Recipes.EntityFrameworkCore.Entities;

[Table("Product", Schema = "Production")]
public partial class Product
{
    [Key]
    public int ProductKey { get; set; }

    [Required]
    [StringLength(50)]
    public string ProductName { get; set; }

    public int ProductLineKey { get; set; }

    [Column(TypeName = "numeric(10, 4)")]
    public decimal? ShippingWeight { get; set; }

    [Column(TypeName = "numeric(10, 4)")]
    public decimal? ProductWeight { get; set; }

    [ForeignKey(nameof(ProductLineKey))]
    [InverseProperty(nameof(ProductLine.Products))]
    public virtual ProductLine ProductLineKeyNavigation { get; set; }
}