using Microsoft.Data.SqlClient;
using Recipes.ScalarValue;
using RDB = RepoDb;
using RepoDb;
using System;

namespace Recipes.RepoDb.ScalarValue
{
    public class ScalarValueScenario : DbRepository<SqlConnection>,
        IScalarValueScenario
    {
        public ScalarValueScenario(string connectionString)
            : base(connectionString, RDB.Enumerations.ConnectionPersistency.Instance)
        { }

        public int? GetDivisionKey(string divisionName)
        {
            var sql = "SELECT DivisionKey FROM [HR].[Division] WHERE (DivisionName = @DivisionName);";

            return ExecuteScalar<int?>(sql, new { divisionName });
        }

        public string GetDivisionName(int divisionKey)
        {
            var sql = "SELECT DivisionName FROM [HR].[Division] WHERE (DivisionKey = @DivisionKey);";

            return ExecuteScalar<string>(sql, new { divisionKey });
        }

        public string? GetDivisionNameOrNull(int divisionKey)
        {
            var sql = "SELECT DivisionName FROM [HR].[Division] WHERE (DivisionKey = @DivisionKey);";

            return ExecuteScalar<string>(sql, new { divisionKey });
        }

        public DateTimeOffset? GetLastReviewCycle(int divisionKey)
        {
            var sql = "SELECT LastReviewCycle FROM [HR].[Division] WHERE (DivisionKey = @DivisionKey);";

            return ExecuteScalar<DateTimeOffset?>(sql, new { divisionKey });
        }

        public int? GetMaxEmployees(int divisionKey)
        {
            var sql = "SELECT MaxEmployees FROM [HR].[Division] WHERE (DivisionKey = @DivisionKey);";

            return ExecuteScalar<int?>(sql, new { divisionKey });
        }

        public DateTime GetModifiedDate(int divisionKey)
        {
            var sql = "SELECT ModifiedDate FROM [HR].[Division] WHERE (DivisionKey = @DivisionKey);";

            return ExecuteScalar<DateTime>(sql, new { divisionKey });
        }

        public decimal? GetSalaryBudget(int divisionKey)
        {
            var sql = "SELECT SalaryBudget FROM [HR].[Division] WHERE (DivisionKey = @DivisionKey);";

            return ExecuteScalar<decimal?>(sql, new { divisionKey });
        }

        public TimeSpan? GetStartTime(int divisionKey)
        {
            var sql = "SELECT StartTime FROM [HR].[Division] WHERE (DivisionKey = @DivisionKey);";

            return ExecuteScalar<TimeSpan?>(sql, new { divisionKey });
        }
    }
}
