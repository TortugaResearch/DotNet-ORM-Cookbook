using System.ComponentModel.DataAnnotations.Schema;
using ServiceStack.DataAnnotations;

namespace Recipes.ServiceStack.Entities
{
    [Schema("Production")]
    public partial class Product
    {
        [PrimaryKey]
        public int ProductKey { get; set; }

        [Required]
        [StringLength(50)]
        public string? ProductName { get; set; }

        [References(typeof(ProductLine)), Alias("ProductLineKey")]
        public int ProductLineId { get; set; }

        public decimal? ShippingWeight { get; set; }

        public decimal? ProductWeight { get; set; }

        [Reference, Alias("ProductLineKeyNavigation")]
        public ProductLine? ProductLine { get; set; }
    }

    //Used for linking the entity to the test framework. Not part of the recipe.
    partial class Product : IProduct
    {
    }
}
