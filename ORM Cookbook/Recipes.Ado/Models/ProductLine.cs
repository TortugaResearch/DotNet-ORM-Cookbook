using Microsoft.Data.SqlClient;

namespace Recipes.Ado.Models;

public class ProductLine : IProductLine<Product>
{
    public ProductLine()
    {
    }

    public ProductLine(SqlDataReader reader)
    {
        if (reader == null)
            throw new ArgumentNullException(nameof(reader), $"{nameof(reader)} is null.");

        ProductLineKey = reader.GetInt32(reader.GetOrdinal("ProductLineKey"));
        ProductLineName = reader.GetString(reader.GetOrdinal("ProductLineName"));
    }

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