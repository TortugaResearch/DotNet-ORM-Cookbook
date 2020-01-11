using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Recipes.NHibernate.Entities
{
    public partial class ProductLine
    {
        public virtual int ProductLineKey { get; set; }

        public virtual string? ProductLineName { get; set; }

        [SuppressMessage("Usage", "CA2227")]
        public virtual IList<Product> Products { get; set; } = new List<Product>();

        public virtual void ApplyKeys()
        {
            foreach (var item in Products)
                item.ProductLine = this;
        }
    }
}
