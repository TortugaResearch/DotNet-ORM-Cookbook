namespace Recipes.SingleColumn;

public interface ISingleColumnScenario
{
    List<int> GetDivisionKeys(int maxDivisionKey);

    List<string> GetDivisionNames(int maxDivisionKey);

    List<DateTimeOffset?> GetLastReviewCycles(int maxDivisionKey);

    List<int?> GetMaxEmployees(int maxDivisionKey);

    List<DateTime> GetModifiedDates(int maxDivisionKey);

    List<decimal?> GetSalaryBudgets(int maxDivisionKey);

    List<TimeSpan?> GetStartTimes(int maxDivisionKey);
}