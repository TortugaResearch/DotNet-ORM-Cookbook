using Microsoft.Data.SqlClient;
using Recipes.ScalarValue;
using RepoDb;
using RepoDb.Enumerations;

namespace Recipes.RepoDB.ScalarValue;

public class ScalarValueScenario : IScalarValueScenario
{
    readonly string m_ConnectionString;

    public ScalarValueScenario(string connectionString)
    {
        m_ConnectionString = connectionString;
    }

    public int? GetDivisionKey(string divisionName)
    {
        var sql = "SELECT DivisionKey FROM [HR].[Division] WHERE (DivisionName = @DivisionName);";

        using (var repository = new DbRepository<SqlConnection>(m_ConnectionString, ConnectionPersistency.Instance))
        return repository.ExecuteScalar<int?>(sql, new { divisionName });
    }

    public string GetDivisionName(int divisionKey)
    {
        var sql = "SELECT DivisionName FROM [HR].[Division] WHERE (DivisionKey = @DivisionKey);";

        using (var repository = new DbRepository<SqlConnection>(m_ConnectionString, ConnectionPersistency.Instance))
        return repository.ExecuteScalar<string>(sql, new { divisionKey });
    }

    public string? GetDivisionNameOrNull(int divisionKey)
    {
        var sql = "SELECT DivisionName FROM [HR].[Division] WHERE (DivisionKey = @DivisionKey);";

        using (var repository = new DbRepository<SqlConnection>(m_ConnectionString, ConnectionPersistency.Instance))
        return repository.ExecuteScalar<string>(sql, new { divisionKey });
    }

    public DateTimeOffset? GetLastReviewCycle(int divisionKey)
    {
        var sql = "SELECT LastReviewCycle FROM [HR].[Division] WHERE (DivisionKey = @DivisionKey);";

        using (var repository = new DbRepository<SqlConnection>(m_ConnectionString, ConnectionPersistency.Instance))
        return repository.ExecuteScalar<DateTimeOffset?>(sql, new { divisionKey });
    }

    public int? GetMaxEmployees(int divisionKey)
    {
        var sql = "SELECT MaxEmployees FROM [HR].[Division] WHERE (DivisionKey = @DivisionKey);";

        using (var repository = new DbRepository<SqlConnection>(m_ConnectionString, ConnectionPersistency.Instance))
        return repository.ExecuteScalar<int?>(sql, new { divisionKey });
    }

    public DateTime GetModifiedDate(int divisionKey)
    {
        var sql = "SELECT ModifiedDate FROM [HR].[Division] WHERE (DivisionKey = @DivisionKey);";

        using (var repository = new DbRepository<SqlConnection>(m_ConnectionString, ConnectionPersistency.Instance))
        return repository.ExecuteScalar<DateTime>(sql, new { divisionKey });
    }

    public decimal? GetSalaryBudget(int divisionKey)
    {
        var sql = "SELECT SalaryBudget FROM [HR].[Division] WHERE (DivisionKey = @DivisionKey);";

        using (var repository = new DbRepository<SqlConnection>(m_ConnectionString, ConnectionPersistency.Instance))
        return repository.ExecuteScalar<decimal?>(sql, new { divisionKey });
    }

    public TimeSpan? GetStartTime(int divisionKey)
    {
        var sql = "SELECT StartTime FROM [HR].[Division] WHERE (DivisionKey = @DivisionKey);";

        using (var repository = new DbRepository<SqlConnection>(m_ConnectionString, ConnectionPersistency.Instance))
        return repository.ExecuteScalar<TimeSpan?>(sql, new { divisionKey });
    }
}