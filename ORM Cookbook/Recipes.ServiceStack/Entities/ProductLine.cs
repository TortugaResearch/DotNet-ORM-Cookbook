using System;
using System.Collections.Generic;
using ServiceStack.DataAnnotations;

namespace Recipes.ServiceStack.Entities
{
    [Schema("Production")]
    public partial class ProductLine
    {
        [PrimaryKey]
        public int ProductLineKey { get; set; }

        [StringLength(50)]
        public string? ProductLineName { get; set; }

        [Reference]
        public ICollection<Product> Products { get; } = new List<Product>();
    }

    //Used for linking the entity to the test framework. Not part of the recipe.
    partial class ProductLine : IProductLine<Product>
    {
    }
}
