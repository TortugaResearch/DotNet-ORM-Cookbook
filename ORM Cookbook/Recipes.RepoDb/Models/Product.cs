using RepoDb.Attributes;

namespace Recipes.RepoDB.Models;

[Map("[Production].[Product]")]
public class Product : IProduct
{
    public int ProductKey { get; set; }
    public int ProductLineKey { get; set; }
    public string? ProductName { get; set; }
    public decimal? ProductWeight { get; set; }
    public decimal? ShippingWeight { get; set; }
}