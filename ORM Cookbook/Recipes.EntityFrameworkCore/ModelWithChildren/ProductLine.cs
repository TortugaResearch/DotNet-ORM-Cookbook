using Recipes.ModelWithChildren;
using System.Collections.Generic;

namespace Recipes.EntityFrameworkCore.Entities
{
    partial class ProductLine : IProductLine<Product>
    {
        ICollection<Product> IProductLine<Product>.Products => Product;
    }
}
