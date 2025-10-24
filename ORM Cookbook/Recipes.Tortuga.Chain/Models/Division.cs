using System.ComponentModel.DataAnnotations.Schema;
using Tortuga.Anchor.Modeling;

namespace Recipes.Chain.Models;

[Table("HR.Division")]
public class Division : IDivision
{
    [IgnoreOnUpdate] //Don't allow this value to be altered during an update operation
    public int CreatedByEmployeeKey { get; set; }

    [IgnoreOnInsert] //Use the database default instead of the user-provided value
    [IgnoreOnUpdate] //Don't allow this value to be altered during an update operation
    public DateTime CreatedDate { get; set; }

    public Guid DivisionId { get; set; }

    public int DivisionKey { get; set; }

    public string? DivisionName { get; set; }

    public float? FloorSpaceBudget { get; set; }

    public decimal? FteBudget { get; set; }

    public DateTimeOffset? LastReviewCycle { get; set; }
    public int? MaxEmployees { get; set; }
    public int ModifiedByEmployeeKey { get; set; }

    [IgnoreOnInsert] //Use the database default instead of the user-provided value
    public DateTime ModifiedDate { get; set; }

    public decimal? SalaryBudget { get; set; }

    public TimeSpan? StartTime { get; set; }

    public decimal? SuppliesBudget { get; set; }
}