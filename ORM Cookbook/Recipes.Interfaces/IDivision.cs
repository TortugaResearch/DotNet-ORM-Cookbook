namespace Recipes;

public interface IDivision
{
    int CreatedByEmployeeKey { get; set; }

    DateTime CreatedDate { get; set; }

    Guid DivisionId { get; set; }

    int DivisionKey { get; set; }

    string? DivisionName { get; set; }

    float? FloorSpaceBudget { get; set; }

    decimal? FteBudget { get; set; }

    DateTimeOffset? LastReviewCycle { get; set; }
    int? MaxEmployees { get; set; }
    int ModifiedByEmployeeKey { get; set; }

    DateTime ModifiedDate { get; set; }

    decimal? SalaryBudget { get; set; }

    TimeSpan? StartTime { get; set; }

    decimal? SuppliesBudget { get; set; }
}