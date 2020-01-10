using Recipes.ModelWithChildren;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.Chain.ModelWithChildren
{
    [Table("Product", Schema = "Production")]
    public class Product : IProduct
    {
        public int ProductKey { get; set; }

        public string? ProductName { get; set; }

        public int ProductLineKey { get; set; }

        public decimal? ShippingWeight { get; set; }

        public decimal? ProductWeight { get; set; }
    }
}
