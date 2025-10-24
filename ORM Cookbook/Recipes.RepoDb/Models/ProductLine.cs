using RepoDb.Attributes;

namespace Recipes.RepoDB.Models;

[Map("[Production].[ProductLine]")]
public class ProductLine : IProductLine<Product>
{
    public int ProductLineKey { get; set; }
    public string? ProductLineName { get; set; }
    public List<Product> Products { get; } = new List<Product>();
    ICollection<Product> IProductLine<Product>.Products => Products;

    public void ApplyKeys()
    {
        Products.ForEach(p =>
            p.ProductLineKey = ProductLineKey);
    }
}