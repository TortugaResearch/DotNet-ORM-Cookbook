namespace Recipes;

public interface IProduct
{
    int ProductKey { get; set; }
    string? ProductName { get; set; }
    decimal? ProductWeight { get; set; }
    decimal? ShippingWeight { get; set; }
}