using Recipes.LinqToDB.Entities;
using Recipes.ScalarValue;
using System;
using System.Linq;

namespace Recipes.LinqToDB.ScalarValue
{
    public class ScalarValueScenario : IScalarValueScenario
    {
        public int? GetDivisionKey(string divisionName)
        {
            using (var db = new OrmCookbook())
                return db.Division.Where(d => d.DivisionName == divisionName).SingleOrDefault()?.DivisionKey;
        }

        public string GetDivisionName(int divisionKey)
        {
            using (var db = new OrmCookbook())
                return db.Division.Where(d => d.DivisionKey == divisionKey).SingleOrDefault()?.DivisionName!;
        }

        public string? GetDivisionNameOrNull(int divisionKey)
        {
            using (var db = new OrmCookbook())
                return db.Division.Where(d => d.DivisionKey == divisionKey).SingleOrDefault()?.DivisionName;
        }

        public DateTimeOffset? GetLastReviewCycle(int divisionKey)
        {
            using (var db = new OrmCookbook())
                return db.Division.Where(d => d.DivisionKey == divisionKey).SingleOrDefault()?.LastReviewCycle;
        }

        public int? GetMaxEmployees(int divisionKey)
        {
            using (var db = new OrmCookbook())
                return db.Division.Where(d => d.DivisionKey == divisionKey).SingleOrDefault()?.MaxEmployees;
        }

        public DateTime GetModifiedDate(int divisionKey)
        {
            using (var db = new OrmCookbook())
                return db.Division.Where(d => d.DivisionKey == divisionKey).Single().ModifiedDate;
        }

        public decimal? GetSalaryBudget(int divisionKey)
        {
            using (var db = new OrmCookbook())
                return db.Division.Where(d => d.DivisionKey == divisionKey).SingleOrDefault()?.SalaryBudget;
        }

        public TimeSpan? GetStartTime(int divisionKey)
        {
            using (var db = new OrmCookbook())
                return db.Division.Where(d => d.DivisionKey == divisionKey).SingleOrDefault()?.StartTime;
        }
    }
}
