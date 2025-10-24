using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.EntityFramework.Entities;

[Table("Production.Product")]
public partial class Product
{
    [Key]
    public int ProductKey { get; set; }

    [Required]
    [StringLength(50)]
    public string? ProductName { get; set; }

    public int ProductLineKey { get; set; }

    [Column(TypeName = "numeric")]
    public decimal? ShippingWeight { get; set; }

    [Column(TypeName = "numeric")]
    public decimal? ProductWeight { get; set; }

    public virtual ProductLine? ProductLine { get; set; }
}