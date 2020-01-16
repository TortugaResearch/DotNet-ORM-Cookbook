using ServiceStack.DataAnnotations;
using System.Collections.Generic;

namespace Recipes.ServiceStack.Entities
{
    [Alias("EmployeeClassification"), Schema("HR")]
    public partial class EmployeeClassification
    {
        [PrimaryKey, AutoIncrement]
        [Alias("EmployeeClassificationKey")]
        public int Id { get; set; }

        public bool IsExempt { get; set; }

        public bool IsEmployee { get; set; }

        [Reference]
        public virtual List<Employee> Employees { get; } = new List<Employee>();

        [Required, StringLength(30)]
        public string? EmployeeClassificationName { get; set; }
    }

    //Used for linking the entity to the test framework. Not part of the recipe.
    partial class EmployeeClassification : IEmployeeClassification
    {
        int IEmployeeClassification.EmployeeClassificationKey { get => Id; set => Id = value; }
        int IReadOnlyEmployeeClassification.EmployeeClassificationKey { get => Id; }
    }
}
