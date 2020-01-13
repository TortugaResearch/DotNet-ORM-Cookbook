using Recipes.Views;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.Chain.Views
{
    [Table("HR.EmployeeClassification")]
    public class EmployeeClassification : IEmployeeClassification
    {
        public int EmployeeClassificationKey { get; set; }
        public string? EmployeeClassificationName { get; set; }
        public bool IsExempt { get; set; }
        public bool IsEmployee { get; set; }
    }
}
