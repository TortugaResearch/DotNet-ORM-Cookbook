using ServiceStack.DataAnnotations;

namespace Recipes.ServiceStack.Entities;

[Alias("EmployeeDetail")]
[Schema("HR")]
public partial class EmployeeDetail
{
    [PrimaryKey, AutoIncrement]
    [Alias("EmployeeKey")]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string? FirstName { get; set; }

    [StringLength(50)]
    public string? MiddleName { get; set; }

    [Required]
    [StringLength(50)]
    public string? LastName { get; set; }

    [StringLength(100)]
    public string? Title { get; set; }

    [StringLength(15)]
    public string? OfficePhone { get; set; }

    [StringLength(15)]
    public string? CellPhone { get; set; }

    [References(typeof(EmployeeClassification))]
    [Alias("EmployeeClassificationKey")]
    public int? EmployeeClassificationId { get; set; }

    [Required, StringLength(30)]
    public string? EmployeeClassificationName { get; set; }

    public bool IsExempt { get; set; }

    public bool IsEmployee { get; set; }
}

//Used for linking the entity to the test framework. Not part of the recipe.
partial class EmployeeDetail : IEmployeeDetail
{
    public int EmployeeKey { get => Id; set => Id = value; }
    public int EmployeeClassificationKey { get => EmployeeClassificationId ?? 0; set => EmployeeClassificationId = value; }
}