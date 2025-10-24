using Microsoft.Data.SqlClient;
using Recipes.ScalarValue;

namespace Recipes.Ado.ScalarValue;

public class ScalarValueScenario : SqlServerScenarioBase, IScalarValueScenario
{
    public ScalarValueScenario(string connectionString) : base(connectionString)
    { }

    public int? GetDivisionKey(string divisionName)
    {
        var sql = "SELECT DivisionKey FROM HR.Division WHERE DivisionName = @DivisionName;";
        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@DivisionName", divisionName);

            var result = cmd.ExecuteScalar();
            //No results will return a `null`. A result containing a null will return a `DBNull.Value`
            if (result == null || result == DBNull.Value)
                return null;
            return (int)result;
        }
    }

    public string GetDivisionName(int divisionKey)
    {
        var sql = "SELECT DivisionName FROM HR.Division WHERE DivisionKey = @DivisionKey;";
        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@DivisionKey", divisionKey);
            return (string)cmd.ExecuteScalar();
        }
    }

    public string? GetDivisionNameOrNull(int divisionKey)
    {
        var sql = "SELECT DivisionName FROM HR.Division WHERE DivisionKey = @DivisionKey;";
        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@DivisionKey", divisionKey);

            var result = cmd.ExecuteScalar();
            if (result == null || result == DBNull.Value)
                return null;
            return (string)result;
        }
    }

    public DateTimeOffset? GetLastReviewCycle(int divisionKey)
    {
        var sql = "SELECT LastReviewCycle FROM HR.Division WHERE DivisionKey = @DivisionKey;";
        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@DivisionKey", divisionKey);

            var result = cmd.ExecuteScalar();
            if (result == null || result == DBNull.Value)
                return null;
            return (DateTimeOffset)result;
        }
    }

    public int? GetMaxEmployees(int divisionKey)
    {
        var sql = "SELECT MaxEmployees FROM HR.Division WHERE DivisionKey = @DivisionKey;";
        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@DivisionKey", divisionKey);

            var result = cmd.ExecuteScalar();
            if (result == null || result == DBNull.Value)
                return null;
            return (int)result;
        }
    }

    public DateTime GetModifiedDate(int divisionKey)
    {
        var sql = "SELECT ModifiedDate FROM HR.Division WHERE DivisionKey = @DivisionKey;";
        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@DivisionKey", divisionKey);

            return (DateTime)cmd.ExecuteScalar();
        }
    }

    public decimal? GetSalaryBudget(int divisionKey)
    {
        var sql = "SELECT SalaryBudget FROM HR.Division WHERE DivisionKey = @DivisionKey;";
        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@DivisionKey", divisionKey);

            var result = cmd.ExecuteScalar();
            if (result == null || result == DBNull.Value)
                return null;
            return (decimal)result;
        }
    }

    public TimeSpan? GetStartTime(int divisionKey)
    {
        var sql = "SELECT StartTime FROM HR.Division WHERE DivisionKey = @DivisionKey;";
        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@DivisionKey", divisionKey);

            var result = cmd.ExecuteScalar();
            if (result == null || result == DBNull.Value)
                return null;
            return (TimeSpan)result;
        }
    }
}