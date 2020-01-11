using Recipes.ModelWithChildren;
using System.Collections.Generic;

namespace Recipes.NHibernate.Entities
{
    partial class ProductLine : IProductLine<Product>
    {
        ICollection<Product> IProductLine<Product>.Products => Products;
    }
}
