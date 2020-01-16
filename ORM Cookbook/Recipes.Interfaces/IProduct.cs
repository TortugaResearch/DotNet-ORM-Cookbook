namespace Recipes
{
    public interface IProduct
    {
        public int ProductKey { get; set; }
        string? ProductName { get; set; }
        decimal? ProductWeight { get; set; }
        decimal? ShippingWeight { get; set; }
    }
}
