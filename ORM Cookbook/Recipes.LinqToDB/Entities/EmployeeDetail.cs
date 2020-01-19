using LinqToDB.Mapping;

namespace Recipes.LinqToDB.Entities
{
    public partial class EmployeeDetail
    {
        [Column]
        public string? CellPhone { get; set; }

        [Column]
        public int EmployeeClassificationKey { get; set; }

        [NotNull]
        [Column]
        public string? EmployeeClassificationName { get; set; }

        [Column]
        public int EmployeeKey { get; set; }

        [NotNull]
        [Column]
        public string? FirstName { get; set; }

        [Column]
        public bool IsEmployee { get; set; }

        [Column]
        public bool IsExempt { get; set; }

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
    partial class EmployeeDetail : IEmployeeDetail
    {
    }
}
