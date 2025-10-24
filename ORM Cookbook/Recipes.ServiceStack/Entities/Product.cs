using ServiceStack.DataAnnotations;
using Ignore = ServiceStack.DataAnnotations.IgnoreAttribute;

namespace Recipes.ServiceStack.Entities;

[Alias("Product"), Schema("Production")]
public partial class Product
{
    [PrimaryKey, AutoIncrement, Alias("ProductKey")]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string? ProductName { get; set; }

    [References(typeof(ProductLine)), Alias("ProductLineKey")]
    public int ProductLineId { get; set; }

    public decimal? ShippingWeight { get; set; }

    public decimal? ProductWeight { get; set; }

    [Reference]
    public ProductLine? ProductLine { get; set; }
}

//Used for linking the entity to the test framework. Not part of the recipe.
partial class Product : IProduct
{
    [Ignore]
    int IProduct.ProductKey
    {
        get => Id;
        set => Id = value;
    }
}