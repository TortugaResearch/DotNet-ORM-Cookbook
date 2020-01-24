using LinqToDB.Mapping;

namespace Recipes.LinqToDB.Entities
{
    [Table("ProductLine", Schema = "Production")]
    public partial class ProductLine
    {
        [PrimaryKey, Identity]
        public int ProductLineKey { get; set; }

        [NotNull]
        [Column]
        public string? ProductLineName { get; set; }
    }
}
