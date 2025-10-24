namespace Recipes;

public interface IProductLine<TProduct>
    where TProduct : IProduct
{
    int ProductLineKey { get; set; }

    string? ProductLineName { get; set; }

    ICollection<TProduct> Products { get; }
}