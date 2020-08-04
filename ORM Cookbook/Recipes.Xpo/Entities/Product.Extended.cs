using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using System;
namespace Recipes.Xpo.Entities
{
    public partial class Product : IProduct
    {
        public Product() : base() { }

        [NonPersistent]
        public int ProductLineKey
        {
            get => ProductLine.ProductLineKey;
            set => ProductLine = Session.GetObjectByKey<ProductLine>(value);
        }
    }
}
