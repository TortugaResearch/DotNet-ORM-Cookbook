using LinqToDB.Mapping;

namespace Recipes.LinqToDB.Entities
{
    public partial class DepartmentDetail
    {
        [Column]
        public int DepartmentKey { get; set; }

        [NotNull]
        [Column]
        public string? DepartmentName { get; set; }

        [Column]
        public int DivisionKey { get; set; }

        [Column]
        public string? DivisionName { get; set; }
    }
}
