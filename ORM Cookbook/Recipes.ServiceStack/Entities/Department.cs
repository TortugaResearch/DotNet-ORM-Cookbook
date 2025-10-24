using ServiceStack.DataAnnotations;

namespace Recipes.ServiceStack.Entities;

[Schema("HR")]
[Alias("Department")]
public class Department
{
    [PrimaryKey, AutoIncrement]
    [Alias("DepartmentKey")]
    public int Id { get; set; }

    [StringLength(30)]
    public string? DepartmentName { get; set; }

    [References(typeof(Division))]
    [Alias("DivisionKey")]
    public int DivisionId { get; set; }

    [Reference]
    public virtual Division? Division { get; set; }
}