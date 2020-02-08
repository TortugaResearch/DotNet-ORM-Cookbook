using Dapper.Contrib.Extensions;

namespace Recipes.Dapper.Models
{
    [Table("HR.EmployeeClassification")]
    public class EmployeeClassification : IEmployeeClassification
    {
        //Table and Key attributes are only used by Dapper.Contrib.
        //They are not needed in the Dapper-only examples.

        [Key]
        public int EmployeeClassificationKey { get; set; }

        public string? EmployeeClassificationName { get; set; }
        public bool IsEmployee { get; set; }
        public bool IsExempt { get; set; }
    }
}
