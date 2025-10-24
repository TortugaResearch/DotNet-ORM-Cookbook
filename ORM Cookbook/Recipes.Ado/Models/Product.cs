using Microsoft.Data.SqlClient;

namespace Recipes.Ado.Models;

public class Product : IProduct
{
    public Product()
    {
    }

    public Product(SqlDataReader reader)
    {
        if (reader == null)
            throw new ArgumentNullException(nameof(reader), $"{nameof(reader)} is null.");

        ProductKey = reader.GetInt32(reader.GetOrdinal("ProductKey"));
        ProductName = reader.GetString(reader.GetOrdinal("ProductName"));
        ProductLineKey = reader.GetInt32(reader.GetOrdinal("ProductLineKey"));

        if (!reader.IsDBNull(reader.GetOrdinal("ShippingWeight")))
            ShippingWeight = reader.GetDecimal(reader.GetOrdinal("ShippingWeight"));
        if (!reader.IsDBNull(reader.GetOrdinal("ProductWeight")))
            ProductWeight = reader.GetDecimal(reader.GetOrdinal("ProductWeight"));
    }

    public int ProductKey { get; set; }

    public int ProductLineKey { get; set; }
    public string? ProductName { get; set; }
    public decimal? ProductWeight { get; set; }
    public decimal? ShippingWeight { get; set; }
}