using Microsoft.Data.SqlClient;
using Recipes.RepoDb.Models;
using Recipes.SingleColumn;
using RDB = RepoDb;
using RepoDb;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Recipes.RepoDb.SingleColumn
{
    public class SingleColumnScenario : BaseRepository<Division, SqlConnection>,
        ISingleColumnScenario
    {
        public SingleColumnScenario(string connectionString)
            : base(connectionString, RDB.Enumerations.ConnectionPersistency.Instance)
        { }

        public List<int> GetDivisionKeys(int maxDivisionKey)
        {
            return Query(e => e.DivisionKey <= maxDivisionKey).Select(d => d.DivisionKey).ToList();
        }

        public List<string> GetDivisionNames(int maxDivisionKey)
        {
            return Query(e => e.DivisionKey <= maxDivisionKey).Select(d => d.DivisionName!).ToList();
        }

        public List<DateTimeOffset?> GetLastReviewCycles(int maxDivisionKey)
        {
            return Query(e => e.DivisionKey <= maxDivisionKey).Select(d => d.LastReviewCycle).ToList();
        }

        public List<int?> GetMaxEmployees(int maxDivisionKey)
        {
            return Query(e => e.DivisionKey <= maxDivisionKey).Select(d => d.MaxEmployees).ToList();
        }

        public List<DateTime> GetModifiedDates(int maxDivisionKey)
        {
            return Query(e => e.DivisionKey <= maxDivisionKey).Select(d => d.ModifiedDate).ToList();
        }

        public List<decimal?> GetSalaryBudgets(int maxDivisionKey)
        {
            return Query(e => e.DivisionKey <= maxDivisionKey).Select(d => d.SalaryBudget).ToList();
        }

        public List<TimeSpan?> GetStartTimes(int maxDivisionKey)
        {
            return Query(e => e.DivisionKey <= maxDivisionKey).Select(d => d.StartTime).ToList();
        }
    }
}