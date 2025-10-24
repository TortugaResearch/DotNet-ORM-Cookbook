using ServiceStack.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Recipes.ServiceStack.Entities;

[Alias("EmployeeClassification"), Schema("HR")]
public partial class EmployeeClassification
{
    [PrimaryKey, AutoIncrement, Alias("EmployeeClassificationKey")]
    public int Id { get; set; }

    [Required, StringLength(30)]
    public string? EmployeeClassificationName { get; set; }

    public bool IsExempt { get; set; }

    public bool IsEmployee { get; set; }

    [Reference]
    [SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "Required by ServiceStack")]
    public List<Employee> Employees { get; set; } = new List<Employee>();
}