using Recipes.SingleColumn;
using ServiceStack.Data;

namespace Recipes.ServiceStack.SingleColumn;

public class SingleColumnScenario : ISingleColumnScenario
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public SingleColumnScenario(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public List<int> GetDivisionKeys(int maxDivisionKey)
    {
        throw new AssertInconclusiveException("TODO");
    }

    public List<string> GetDivisionNames(int maxDivisionKey)
    {
        throw new AssertInconclusiveException("TODO");
    }

    public List<DateTimeOffset?> GetLastReviewCycles(int maxDivisionKey)
    {
        throw new AssertInconclusiveException("TODO");
    }

    public List<int?> GetMaxEmployees(int maxDivisionKey)
    {
        throw new AssertInconclusiveException("TODO");
    }

    public List<DateTime> GetModifiedDates(int maxDivisionKey)
    {
        throw new AssertInconclusiveException("TODO");
    }

    public List<decimal?> GetSalaryBudgets(int maxDivisionKey)
    {
        throw new AssertInconclusiveException("TODO");
    }

    public List<TimeSpan?> GetStartTimes(int maxDivisionKey)
    {
        throw new AssertInconclusiveException("TODO");
    }
}