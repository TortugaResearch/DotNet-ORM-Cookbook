using Recipes.SingleColumn;

namespace Recipes.PetaPoco.SingleColumn;

public class SingleColumnScenario : ScenarioBase, ISingleColumnScenario
{
    public SingleColumnScenario(string connectionString) : base(connectionString)
    { }

    public List<int> GetDivisionKeys(int maxDivisionKey)
    {
        throw new NotImplementedException();
    }

    public List<string> GetDivisionNames(int maxDivisionKey)
    {
        throw new NotImplementedException();
    }

    public List<DateTimeOffset?> GetLastReviewCycles(int maxDivisionKey)
    {
        throw new NotImplementedException();
    }

    public List<int?> GetMaxEmployees(int maxDivisionKey)
    {
        throw new NotImplementedException();
    }

    public List<DateTime> GetModifiedDates(int maxDivisionKey)
    {
        throw new NotImplementedException();
    }

    public List<decimal?> GetSalaryBudgets(int maxDivisionKey)
    {
        throw new NotImplementedException();
    }

    public List<TimeSpan?> GetStartTimes(int maxDivisionKey)
    {
        throw new NotImplementedException();
    }
}