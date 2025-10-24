using Recipes.ScalarValue;

namespace Recipes.DbConnector.ScalarValue;

public class ScalarValueScenario : ScenarioBase, IScalarValueScenario
{
    public ScalarValueScenario(string connectionString) : base(connectionString)
    { }

    public int? GetDivisionKey(string divisionName)
    {
        var sql = "SELECT DivisionKey FROM HR.Division WHERE DivisionName = @divisionName;";

        return DbConnector.Scalar<int?>(sql, new { divisionName }).Execute();
    }

    public string GetDivisionName(int divisionKey)
    {
        var sql = "SELECT DivisionName FROM HR.Division WHERE DivisionKey = @divisionKey;";

        return DbConnector.Scalar<string>(sql, new { divisionKey }).Execute();
    }

    public string? GetDivisionNameOrNull(int divisionKey)
    {
        var sql = "SELECT DivisionName FROM HR.Division WHERE DivisionKey = @divisionKey;";

        return DbConnector.Scalar<string?>(sql, new { divisionKey }).Execute();
    }

    public DateTimeOffset? GetLastReviewCycle(int divisionKey)
    {
        var sql = "SELECT LastReviewCycle FROM HR.Division WHERE DivisionKey = @divisionKey;";

        return DbConnector.Scalar<DateTimeOffset?>(sql, new { divisionKey }).Execute();
    }

    public int? GetMaxEmployees(int divisionKey)
    {
        var sql = "SELECT MaxEmployees FROM HR.Division WHERE DivisionKey = @divisionKey;";

        return DbConnector.Scalar<int?>(sql, new { divisionKey }).Execute();
    }

    public DateTime GetModifiedDate(int divisionKey)
    {
        var sql = "SELECT ModifiedDate FROM HR.Division WHERE DivisionKey = @divisionKey;";

        return DbConnector.Scalar<DateTime>(sql, new { divisionKey }).Execute();
    }

    public decimal? GetSalaryBudget(int divisionKey)
    {
        var sql = "SELECT SalaryBudget FROM HR.Division WHERE DivisionKey = @divisionKey;";

        return DbConnector.Scalar<decimal?>(sql, new { divisionKey }).Execute();
    }

    public TimeSpan? GetStartTime(int divisionKey)
    {
        var sql = "SELECT StartTime FROM HR.Division WHERE DivisionKey = @divisionKey;";

        return DbConnector.Scalar<TimeSpan?>(sql, new { divisionKey }).Execute();
    }
}