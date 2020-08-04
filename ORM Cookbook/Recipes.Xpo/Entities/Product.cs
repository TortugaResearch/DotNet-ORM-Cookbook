using System;
using DevExpress.Xpo;

namespace Recipes.Xpo.Entities
{
    [Persistent(@"Production.Product")]
    public partial class Product : XPLiteObject
    {
        int fProductKey;
        [Key(true)]
        public int ProductKey
        {
            get { return fProductKey; }
            set { SetPropertyValue<int>(nameof(ProductKey), ref fProductKey, value); }
        }
        string? fProductName;
        [Size(50)]
        public string? ProductName
        {
            get { return fProductName; }
            set { SetPropertyValue<string?>(nameof(ProductName), ref fProductName, value); }
        }
        ProductLine fProductLine;
        [Persistent("ProductLineKey")]
        [Association(@"Production_ProductReferencesProduction_ProductLine"), Aggregated]
        public ProductLine ProductLine
        {
            get { return fProductLine; }
            set { SetPropertyValue<ProductLine>(nameof(ProductLine), ref fProductLine, value); }
        }
        decimal? fShippingWeight;
        public decimal? ShippingWeight
        {
            get { return fShippingWeight; }
            set { SetPropertyValue<decimal?>(nameof(ShippingWeight), ref fShippingWeight, value); }
        }
        decimal? fProductWeight;
        public decimal? ProductWeight
        {
            get { return fProductWeight; }
            set { SetPropertyValue<decimal?>(nameof(ProductWeight), ref fProductWeight, value); }
        }
        public Product(Session session) : base(session) { }
    }

}
