using LinqToDB.Mapping;

namespace Recipes.LinqToDB.Entities
{
    [Table("Employee", Schema = "HR")]
    public partial class Employee
    {
        [Column]
        public string? CellPhone { get; set; }

        [Column]
        public int EmployeeClassificationKey { get; set; }

        [PrimaryKey, Identity]
        public int EmployeeKey { get; set; }

        [NotNull]
        [Column]
        public string? FirstName { get; set; }

        [NotNull]
        [Column]
        public string? LastName { get; set; }

        [Column]
        public string? MiddleName { get; set; }

        [Column]
        public string? OfficePhone { get; set; }

        [Column]
        public string? Title { get; set; }
    }

    //Used for linking the entity to the test framework. Not part of the recipe.
    partial class Employee : IEmployeeSimple
    {
    }
}
