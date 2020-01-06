using System.Collections.Generic;
using ServiceStack.DataAnnotations;

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
}