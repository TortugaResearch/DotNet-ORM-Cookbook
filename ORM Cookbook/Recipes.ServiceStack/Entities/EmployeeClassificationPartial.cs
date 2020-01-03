using ServiceStack.DataAnnotations;
using System.Collections.Generic;

namespace Recipes.ServiceStack.Entities
{
    [Alias("EmployeeClassification")]
    [Schema("HR")]
    public partial class EmployeeClassificationPartial
    {
        [PrimaryKey, AutoIncrement]
        [Alias("EmployeeClassificationKey")]
        public int Id { get; set; }

        [Reference] public virtual List<Employee> Employees { get; } = new List<Employee>();

        [Ignore]
        public int EmployeeClassificationKey
        {
            get => Id;
            set => Id = value;
        }

        [Required] [StringLength(30)] public string? EmployeeClassificationName { get; set; }

        public bool IsExempt { get; set; }

        [Required] public bool IsEmployee { get; set; }
    }
}
