namespace Recipes.NHibernate.Entities
{
    public partial class Product : IProduct
    {
        public virtual int ProductKey { get; set; }

        public virtual string? ProductName { get; set; }

        //public virtual int ProductLineKey { get; set; }

        public virtual decimal? ShippingWeight { get; set; }

        public virtual decimal? ProductWeight { get; set; }

        public virtual ProductLine? ProductLine { get; set; }
    }
}
