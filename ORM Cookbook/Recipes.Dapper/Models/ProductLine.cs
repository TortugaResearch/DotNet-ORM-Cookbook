namespace Recipes.Dapper.Models;

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