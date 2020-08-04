using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Xpo.Entities
{
    public partial class ProductLine : IProductLine<Product>
    {
        public ProductLine() : base()
        {

        }
        ICollection<Product> IProductLine<Product>.Products => (ICollection<Product>)Products;
    }
}
