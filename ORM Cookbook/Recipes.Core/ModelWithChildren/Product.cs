namespace Recipes.ModelWithChildren
{
    public interface IProduct
    {
        public int ProductKey { get; set; }
        string? ProductName { get; set; }
        decimal? ShippingWeight { get; set; }
        decimal? ProductWeight { get; set; }
    }
}
