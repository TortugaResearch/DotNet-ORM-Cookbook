using ServiceStack.DataAnnotations;
using Ignore = ServiceStack.DataAnnotations.IgnoreAttribute;

namespace Recipes.ServiceStack.Entities;

[Alias("Division")]
[Schema("HR")]
public partial class Division : IDivision
{
    [PrimaryKey, AutoIncrement]
    [Alias("DivisionKey")]
    public int Id { get; set; }

    public Guid DivisionId { get; set; }

    [Required]
    [StringLength(30)]
    public string? DivisionName { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public int CreatedByEmployeeKey { get; set; }
    public int ModifiedByEmployeeKey { get; set; }
    public decimal? SalaryBudget { get; set; }
    public decimal? FteBudget { get; set; }
    public decimal? SuppliesBudget { get; set; }
    public float? FloorSpaceBudget { get; set; }
    public int? MaxEmployees { get; set; }
    public DateTimeOffset? LastReviewCycle { get; set; }
    public TimeSpan? StartTime { get; set; }

    [Reference]
    public virtual List<Department> Departments { get; } = new List<Department>();
}

//Used for linking the entity to the test framework. Not part of the recipe.
partial class Division : IDivision
{
    [Ignore]
    int IDivision.DivisionKey { get => Id; set => Id = value; }
}