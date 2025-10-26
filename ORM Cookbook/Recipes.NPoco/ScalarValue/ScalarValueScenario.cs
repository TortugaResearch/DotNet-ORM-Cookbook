using Recipes.ScalarValue;

namespace Recipes.NPoco.ScalarValue;

public class ScalarValueScenario : ScenarioBase, IScalarValueScenario
{
    public ScalarValueScenario(string connectionString) : base(connectionString)
    { }

    public int? GetDivisionKey(string divisionName)
    {
        throw new NotImplementedException();
    }

    public string? GetDivisionName(int divisionKey)
    {
        throw new NotImplementedException();
    }

    public string? GetDivisionNameOrNull(int divisionKey)
    {
        throw new NotImplementedException();
    }

    public DateTimeOffset? GetLastReviewCycle(int divisionKey)
    {
        throw new NotImplementedException();
    }

    public int? GetMaxEmployees(int divisionKey)
    {
        throw new NotImplementedException();
    }

    public DateTime GetModifiedDate(int divisionKey)
    {
        throw new NotImplementedException();
    }

    public decimal? GetSalaryBudget(int divisionKey)
    {
        throw new NotImplementedException();
    }

    public TimeSpan? GetStartTime(int divisionKey)
    {
        throw new NotImplementedException();
    }
}