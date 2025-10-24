using Recipes.SingleColumn;

namespace Recipes.DbConnector.SingleColumn;

public class SingleColumnScenario : ScenarioBase, ISingleColumnScenario
{
    public SingleColumnScenario(string connectionString) : base(connectionString)
    { }

    public List<int> GetDivisionKeys(int maxDivisionKey)
    {
        var sql = "SELECT DivisionKey FROM HR.Division WHERE DivisionKey < @maxDivisionKey;";

        return DbConnector.ReadToList<int>(sql, new { maxDivisionKey }).Execute();
    }

    public List<string> GetDivisionNames(int maxDivisionKey)
    {
        var sql = "SELECT DivisionName FROM HR.Division WHERE DivisionKey < @maxDivisionKey;";

        return DbConnector.ReadToList<string>(sql, new { maxDivisionKey }).Execute();
    }

    public List<DateTimeOffset?> GetLastReviewCycles(int maxDivisionKey)
    {
        var sql = "SELECT LastReviewCycle FROM HR.Division WHERE DivisionKey < @maxDivisionKey;";

        return DbConnector.ReadToList<DateTimeOffset?>(sql, new { maxDivisionKey }).Execute();
    }

    public List<int?> GetMaxEmployees(int maxDivisionKey)
    {
        var sql = "SELECT MaxEmployees FROM HR.Division WHERE DivisionKey < @maxDivisionKey;";

        return DbConnector.ReadToList<int?>(sql, new { maxDivisionKey }).Execute();
    }

    public List<DateTime> GetModifiedDates(int maxDivisionKey)
    {
        var sql = "SELECT ModifiedDate FROM HR.Division WHERE DivisionKey < @maxDivisionKey;";

        return DbConnector.ReadToList<DateTime>(sql, new { maxDivisionKey }).Execute();
    }

    public List<decimal?> GetSalaryBudgets(int maxDivisionKey)
    {
        var sql = "SELECT SalaryBudget FROM HR.Division WHERE DivisionKey < @maxDivisionKey;";

        return DbConnector.ReadToList<decimal?>(sql, new { maxDivisionKey }).Execute();
    }

    public List<TimeSpan?> GetStartTimes(int maxDivisionKey)
    {
        var sql = "SELECT StartTime FROM HR.Division WHERE DivisionKey < @maxDivisionKey;";

        return DbConnector.ReadToList<TimeSpan?>(sql, new { maxDivisionKey }).Execute();
    }
}