using ServiceStack.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Ignore = ServiceStack.DataAnnotations.IgnoreAttribute;

namespace Recipes.ServiceStack.Entities;

[Alias("ProductLine"), Schema("Production")]
public partial class ProductLine
{
    [PrimaryKey, AutoIncrement, Alias("ProductLineKey")]
    public int Id { get; set; }

    [StringLength(50)]
    public string? ProductLineName { get; set; }

    [Reference]
    [SuppressMessage("Usage", "CA2227:Collection properties should be read only",
        Justification = "Required by ServiceStack")]
    public List<Product> Products { get; set; } = new List<Product>();
}

//Used for linking the entity to the test framework. Not part of the recipe.
partial class ProductLine : IProductLine<Product>
{
    [Ignore]
    int IProductLine<Product>.ProductLineKey
    {
        get => Id;
        set => Id = value;
    }

    [Ignore]
    ICollection<Product> IProductLine<Product>.Products => Products;
}