using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.Chain.Models;

[Table("ProductLine", Schema = "Production")]
public class ProductLine : IProductLine<Product>
{
    public int ProductLineKey { get; set; }

    public string? ProductLineName { get; set; }

    public List<Product> Products { get; } = new List<Product>();

    ICollection<Product> IProductLine<Product>.Products => Products;

    public void ApplyKeys()
    {
        foreach (var item in Products)
            item.ProductLineKey = ProductLineKey;
    }
}