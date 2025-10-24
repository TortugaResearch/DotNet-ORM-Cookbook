using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.Chain.Models;

[Table("HR.EmployeeClassification")]
public class EmployeeClassification : IEmployeeClassification
{
    public int EmployeeClassificationKey { get; set; }
    public string? EmployeeClassificationName { get; set; }
    public bool IsEmployee { get; set; }
    public bool IsExempt { get; set; }
}
