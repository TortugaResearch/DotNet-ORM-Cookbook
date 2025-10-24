using ServiceStack.DataAnnotations;
using Ignore = ServiceStack.DataAnnotations.IgnoreAttribute;

namespace Recipes.ServiceStack.Entities;

[Alias("EmployeeClassification")]
[Schema("HR")]
public partial class EmployeeClassificationPartial
{
    [PrimaryKey, AutoIncrement]
    [Alias("EmployeeClassificationKey")]
    public int Id { get; set; }

    [Reference]
    public virtual List<Employee> Employees { get; } = new List<Employee>();

    [Ignore]
    public int EmployeeClassificationKey
    {
        get => Id;
        set => Id = value;
    }

    [Required]
    [StringLength(30)]
    public string? EmployeeClassificationName { get; set; }

    public bool IsExempt { get; set; }

    public bool IsEmployee { get; set; }
}

//Used for linking the entity to the test framework. Not part of the recipe.
partial class EmployeeClassificationPartial : IEmployeeClassification
{
    [Ignore]
    int IEmployeeClassification.EmployeeClassificationKey
    {
        get => Id;
        set => Id = value;
    }
}