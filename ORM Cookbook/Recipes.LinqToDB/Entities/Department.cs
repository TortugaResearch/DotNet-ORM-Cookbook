using LinqToDB.Mapping;

namespace Recipes.LinqToDB.Entities
{
    [Table("Department", Schema = "HR")]
    public partial class Department
    {
        [PrimaryKey, Identity]
        public int DepartmentKey { get; set; }

        [NotNull]
        [Column]
        public string? DepartmentName { get; set; }

        [Column]
        public int DivisionKey { get; set; }
    }
}
