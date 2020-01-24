using LinqToDB.Mapping;

namespace Recipes.LinqToDB.Entities
{
    [Table("Product", Schema = "Production")]
    public partial class Product
    {
        [PrimaryKey, Identity]
        public int ProductKey { get; set; }

        [Column]
        public int ProductLineKey { get; set; }

        [NotNull]
        [Column]
        public string? ProductName { get; set; }

        [Column]
        public decimal? ProductWeight { get; set; }

        [Column]
        public decimal? ShippingWeight { get; set; }
    }

    //Used for linking the entity to the test framework. Not part of the recipe.
    partial class Product : IProduct
    {
    }
}
