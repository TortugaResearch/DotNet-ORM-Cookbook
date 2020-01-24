using LinqToDB.Mapping;

namespace Recipes.LinqToDB.Entities
{
    [Table("EmployeeClassification", Schema = "HR")]
    public partial class EmployeeClassification
    {
        [PrimaryKey, Identity]
        public int EmployeeClassificationKey { get; set; }

        [Column]
        [NotNull]
        public string? EmployeeClassificationName { get; set; }

        [Column]
        public bool IsEmployee { get; set; }

        [Column]
        public bool IsExempt { get; set; }
    }

    //Used for linking the entity to the test framework. Not part of the recipe.
    partial class EmployeeClassification : IEmployeeClassification
    {
    }
}
