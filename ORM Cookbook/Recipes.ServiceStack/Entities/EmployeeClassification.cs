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

        [Required, StringLength(30)]
        public string? EmployeeClassificationName { get; set; }

        public bool IsExempt { get; set; }

        public bool IsEmployee { get; set; }

        [Reference]
        public virtual List<Employee> Employees { get; } = new List<Employee>();
    }

    //Used for linking the entity to the test framework. Not part of the recipe.
    partial class EmployeeClassification : IEmployeeClassification, IReadOnlyEmployeeClassification
    {
        int IEmployeeClassification.EmployeeClassificationKey { get => Id; set => Id = value; }
        int IReadOnlyEmployeeClassification.EmployeeClassificationKey { get => Id; }
    }
}
