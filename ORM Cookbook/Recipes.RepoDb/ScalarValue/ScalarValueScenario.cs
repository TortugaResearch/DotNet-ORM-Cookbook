using Recipes.RepoDb.Models;
using Recipes.ScalarValue;
using RepoDb;
using RDB = RepoDb;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace Recipes.RepoDb.ScalarValue
{
    public class ScalarValueScenario : BaseRepository<Division, SqlConnection>,
        IScalarValueScenario
    {
        public ScalarValueScenario(string connectionString)
            : base(connectionString, RDB.Enumerations.ConnectionPersistency.Instance)
        { }

        public int? GetDivisionKey(string divisionName)
        {
            var division = Query(
                e => e.DivisionName == divisionName).FirstOrDefault();
            return division?.DivisionKey;
        }

        public string GetDivisionName(int divisionKey)
        {
            var division = Query(e => e.DivisionKey == divisionKey).FirstOrDefault();
            return division?.DivisionName != null ?
                division.DivisionName : string.Empty;
        }

        public string? GetDivisionNameOrNull(int divisionKey)
        {
            var division = Query(e => e.DivisionKey == divisionKey).FirstOrDefault();
            return division?.DivisionName;
        }

        public DateTimeOffset? GetLastReviewCycle(int divisionKey)
        {
            var division = Query(e => e.DivisionKey == divisionKey).FirstOrDefault();
            return division?.LastReviewCycle;
        }

        public int? GetMaxEmployees(int divisionKey)
        {
            var division = Query(e => e.DivisionKey == divisionKey).FirstOrDefault();
            return division?.MaxEmployees;
        }

        public DateTime GetModifiedDate(int divisionKey)
        {
            var division = Query(e => e.DivisionKey == divisionKey).FirstOrDefault();
            return division.ModifiedDate;
        }

        public decimal? GetSalaryBudget(int divisionKey)
        {
            var division = Query(e => e.DivisionKey == divisionKey).FirstOrDefault();
            return division.SalaryBudget;
        }

        public TimeSpan? GetStartTime(int divisionKey)
        {
            var division = Query(e => e.DivisionKey == divisionKey).FirstOrDefault();
            return division.StartTime;
        }
    }
}
