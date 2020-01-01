using ServiceStack.DataAnnotations;
using System.Collections.Generic;

namespace Recipes.ServiceStack.Entities
{
    [Alias("EmployeeClassification")]
    [Schema("HR")]
    public partial class EmployeeClassification
    {
        [PrimaryKey, AutoIncrement]
        [Alias("EmployeeClassificationKey")]
        public int Id { get; set; }

        [Default(0)]
        public bool IsExempt { get; set; }

        [Default(1)]
        public bool? IsEmployee { get; set; }

        [Reference]
        public virtual List<Employee> Employees { get; } = new List<Employee>();

        [Required, StringLength(30)]
        public string? EmployeeClassificationName { get; set; }
    }
}
