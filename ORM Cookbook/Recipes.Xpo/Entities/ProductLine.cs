using DevExpress.Xpo;
using System;

namespace Recipes.Xpo.Entities
{

    [Persistent(@"Production.ProductLine")]
    public partial class ProductLine : XPLiteObject
    {
        int fProductLineKey;
        [Key(true)]
        public int ProductLineKey
        {
            get { return fProductLineKey; }
            set { SetPropertyValue<int>(nameof(ProductLineKey), ref fProductLineKey, value); }
        }
        string? fProductLineName;
        [Indexed(Name = @"UX_ProductLine_ProductLineName", Unique = true)]
        [Size(50)]
        public string? ProductLineName
        {
            get { return fProductLineName; }
            set { SetPropertyValue<string?>(nameof(ProductLineName), ref fProductLineName, value); }
        }

        [Association(@"Production_ProductReferencesProduction_ProductLine"), Aggregated]
        public XPCollection<Product> Products { get { return GetCollection<Product>(nameof(Products)); } }
        public ProductLine(Session session) : base(session) { }
    }

}
