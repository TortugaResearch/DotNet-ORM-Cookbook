using DbConnector.Core.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.DbConnector.Models;

[Table("Production.Product")]
public class Product : IProduct
{
    public readonly static string TableName = typeof(Product).GetAttributeValue((TableAttribute ta) => ta.Name) ?? typeof(Product).Name;

    public int ProductKey { get; set; }

    public int ProductLineKey { get; set; }
    public string? ProductName { get; set; }
    public decimal? ProductWeight { get; set; }
    public decimal? ShippingWeight { get; set; }
}
