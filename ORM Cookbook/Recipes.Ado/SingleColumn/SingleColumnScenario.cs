using Microsoft.Data.SqlClient;
using Recipes.SingleColumn;

namespace Recipes.Ado.SingleColumn;

public class SingleColumnScenario : SqlServerScenarioBase, ISingleColumnScenario
{
    public SingleColumnScenario(string connectionString) : base(connectionString)
    { }

    public List<int> GetDivisionKeys(int maxDivisionKey)
    {
        var sql = "SELECT DivisionKey FROM HR.Division WHERE DivisionKey < @MaxDivisionKey;";
        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@MaxDivisionKey", maxDivisionKey);

            var results = new List<int>();
            using (var reader = cmd.ExecuteReader())
                while (reader.Read())
                    results.Add(reader.GetInt32(0));

            return results;
        }
    }

    public List<string> GetDivisionNames(int maxDivisionKey)
    {
        var sql = "SELECT DivisionName FROM HR.Division WHERE DivisionKey < @MaxDivisionKey;";
        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@MaxDivisionKey", maxDivisionKey);

            var results = new List<string>();
            using (var reader = cmd.ExecuteReader())
                while (reader.Read())
                    results.Add(reader.GetString(0));

            return results;
        }
    }

    public List<DateTimeOffset?> GetLastReviewCycles(int maxDivisionKey)
    {
        var sql = "SELECT LastReviewCycle FROM HR.Division WHERE DivisionKey < @MaxDivisionKey;";
        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@MaxDivisionKey", maxDivisionKey);

            var results = new List<DateTimeOffset?>();
            using (var reader = cmd.ExecuteReader())
                while (reader.Read())
                    if (reader.IsDBNull(0))
                        results.Add(null);
                    else
                        results.Add(reader.GetDateTimeOffset(0));

            return results;
        }
    }

    public List<int?> GetMaxEmployees(int maxDivisionKey)
    {
        var sql = "SELECT MaxEmployees FROM HR.Division WHERE DivisionKey < @MaxDivisionKey;";
        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@MaxDivisionKey", maxDivisionKey);

            var results = new List<int?>();
            using (var reader = cmd.ExecuteReader())
                while (reader.Read())
                    if (reader.IsDBNull(0))
                        results.Add(null);
                    else
                        results.Add(reader.GetInt32(0));

            return results;
        }
    }

    public List<DateTime> GetModifiedDates(int maxDivisionKey)
    {
        var sql = "SELECT ModifiedDate FROM HR.Division WHERE DivisionKey < @MaxDivisionKey;";
        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@MaxDivisionKey", maxDivisionKey);

            var results = new List<DateTime>();
            using (var reader = cmd.ExecuteReader())
                while (reader.Read())
                    results.Add(reader.GetDateTime(0));

            return results;
        }
    }

    public List<decimal?> GetSalaryBudgets(int maxDivisionKey)
    {
        var sql = "SELECT SalaryBudget FROM HR.Division WHERE DivisionKey < @MaxDivisionKey;";
        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@MaxDivisionKey", maxDivisionKey);

            var results = new List<decimal?>();
            using (var reader = cmd.ExecuteReader())
                while (reader.Read())
                    if (reader.IsDBNull(0))
                        results.Add(null);
                    else
                        results.Add(reader.GetDecimal(0));

            return results;
        }
    }

    public List<TimeSpan?> GetStartTimes(int maxDivisionKey)
    {
        var sql = "SELECT StartTime FROM HR.Division WHERE DivisionKey < @MaxDivisionKey;";
        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@MaxDivisionKey", maxDivisionKey);

            var results = new List<TimeSpan?>();
            using (var reader = cmd.ExecuteReader())
                while (reader.Read())
                    if (reader.IsDBNull(0))
                        results.Add(null);
                    else
                        results.Add(reader.GetTimeSpan(0));

            return results;
        }
    }
}