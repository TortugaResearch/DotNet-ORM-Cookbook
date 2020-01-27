using Dapper;
using Microsoft.Data.SqlClient;
using Recipes.SingleColumn;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Dapper.SingleColumn
{
    public class SingleColumnScenario : ScenarioBase, ISingleColumnScenario
    {
        public SingleColumnScenario(string connectionString) : base(connectionString)
        { }

        public List<int> GetDivisionKeys(int maxDivisionKey)
        {
            var sql = "SELECT DivisionKey FROM HR.Division WHERE DivisionKey < @MaxDivisionKey;";
            using (var con = OpenConnection())
                return con.Query<int>(sql, new { maxDivisionKey }).ToList();
        }

        public List<string> GetDivisionNames(int maxDivisionKey)
        {
            var sql = "SELECT DivisionName FROM HR.Division WHERE DivisionKey < @MaxDivisionKey;";
            using (var con = OpenConnection())
                return con.Query<string>(sql, new { maxDivisionKey }).ToList();
        }

        public List<DateTimeOffset?> GetLastReviewCycles(int maxDivisionKey)
        {
            var sql = "SELECT LastReviewCycle FROM HR.Division WHERE DivisionKey < @MaxDivisionKey;";
            using (var con = OpenConnection())
                return con.Query<DateTimeOffset?>(sql, new { maxDivisionKey }).ToList();
        }

        public List<int?> GetMaxEmployees(int maxDivisionKey)
        {
            var sql = "SELECT MaxEmployees FROM HR.Division WHERE DivisionKey < @MaxDivisionKey;";
            using (var con = OpenConnection())
                return con.Query<int?>(sql, new { maxDivisionKey }).ToList();
        }

        public List<DateTime> GetModifiedDates(int maxDivisionKey)
        {
            var sql = "SELECT ModifiedDate FROM HR.Division WHERE DivisionKey < @MaxDivisionKey;";
            using (var con = OpenConnection())
                return con.Query<DateTime>(sql, new { maxDivisionKey }).ToList();
        }

        public List<decimal?> GetSalaryBudgets(int maxDivisionKey)
        {
            var sql = "SELECT SalaryBudget FROM HR.Division WHERE DivisionKey < @MaxDivisionKey;";
            using (var con = OpenConnection())
                return con.Query<decimal?>(sql, new { maxDivisionKey }).ToList();
        }

        public List<TimeSpan?> GetStartTimes(int maxDivisionKey)
        {
            var sql = "SELECT StartTime FROM HR.Division WHERE DivisionKey < @MaxDivisionKey;";
            using (var con = OpenConnection())
                return con.Query<TimeSpan?>(sql, new { maxDivisionKey }).ToList();
        }
    }
}
