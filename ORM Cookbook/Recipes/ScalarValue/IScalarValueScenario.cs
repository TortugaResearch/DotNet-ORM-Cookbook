namespace Recipes.ScalarValue;

public interface IScalarValueScenario
{
    int? GetDivisionKey(string divisionName);

    string? GetDivisionName(int divisionKey);

    string? GetDivisionNameOrNull(int divisionKey);

    DateTimeOffset? GetLastReviewCycle(int divisionKey);

    int? GetMaxEmployees(int divisionKey);

    DateTime GetModifiedDate(int divisionKey);

    decimal? GetSalaryBudget(int divisionKey);

    TimeSpan? GetStartTime(int divisionKey);
}