using Dapper;
using Recipes.ScalarValue;

namespace Recipes.Dapper.ScalarValue;

public class ScalarValueScenario : ScenarioBase, IScalarValueScenario
{
    public ScalarValueScenario(string connectionString) : base(connectionString)
    { }

    public int? GetDivisionKey(string divisionName)
    {
        var sql = "SELECT DivisionKey FROM HR.Division WHERE DivisionName = @DivisionName;";
        using (var con = OpenConnection())
            return con.ExecuteScalar<int?>(sql, new { divisionName });
    }

    public string? GetDivisionName(int divisionKey)
    {
        var sql = "SELECT DivisionName FROM HR.Division WHERE DivisionKey = @DivisionKey;";
        using (var con = OpenConnection())
            return con.ExecuteScalar<string>(sql, new { divisionKey });
    }

    public string? GetDivisionNameOrNull(int divisionKey)
    {
        var sql = "SELECT DivisionName FROM HR.Division WHERE DivisionKey = @DivisionKey;";
        using (var con = OpenConnection())
            return con.ExecuteScalar<string?>(sql, new { divisionKey });
    }

    public DateTimeOffset? GetLastReviewCycle(int divisionKey)
    {
        var sql = "SELECT LastReviewCycle FROM HR.Division WHERE DivisionKey = @DivisionKey;";
        using (var con = OpenConnection())
            return con.ExecuteScalar<DateTimeOffset?>(sql, new { divisionKey });
    }

    public int? GetMaxEmployees(int divisionKey)
    {
        var sql = "SELECT MaxEmployees FROM HR.Division WHERE DivisionKey = @DivisionKey;";
        using (var con = OpenConnection())
            return con.ExecuteScalar<int?>(sql, new { divisionKey });
    }

    public DateTime GetModifiedDate(int divisionKey)
    {
        var sql = "SELECT ModifiedDate FROM HR.Division WHERE DivisionKey = @DivisionKey;";
        using (var con = OpenConnection())
            return con.ExecuteScalar<DateTime>(sql, new { divisionKey });
    }

    public decimal? GetSalaryBudget(int divisionKey)
    {
        var sql = "SELECT SalaryBudget FROM HR.Division WHERE DivisionKey = @DivisionKey;";
        using (var con = OpenConnection())
            return con.ExecuteScalar<decimal?>(sql, new { divisionKey });
    }

    public TimeSpan? GetStartTime(int divisionKey)
    {
        var sql = "SELECT StartTime FROM HR.Division WHERE DivisionKey = @DivisionKey;";
        using (var con = OpenConnection())
            return con.ExecuteScalar<TimeSpan?>(sql, new { divisionKey });
    }
}