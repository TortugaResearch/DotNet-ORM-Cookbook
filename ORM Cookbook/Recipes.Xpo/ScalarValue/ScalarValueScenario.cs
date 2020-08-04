using Recipes.Xpo.Entities;
using Recipes.ScalarValue;
using System;
using System.Linq;
using DevExpress.Xpo;

namespace Recipes.Xpo.ScalarValue
{
    public class ScalarValueScenario : IScalarValueScenario
    {

        public int? GetDivisionKey(string divisionName)
        {
            using (var uow = new UnitOfWork())
                return uow.Query<Division>().Where(d => d.DivisionName == divisionName).Select(d => (int?)d.DivisionKey).SingleOrDefault();
        }

        public string GetDivisionName(int divisionKey)
        {
            using (var uow = new UnitOfWork())
                return uow.Query<Division>().Where(d => d.DivisionKey == divisionKey).Select(d => d.DivisionName!).Single();
        }

        public string? GetDivisionNameOrNull(int divisionKey)
        {
            using (var uow = new UnitOfWork())
                return uow.Query<Division>().Where(d => d.DivisionKey == divisionKey).Select(d => d.DivisionName!).SingleOrDefault();
        }

        public DateTimeOffset? GetLastReviewCycle(int divisionKey)
        {
            using (var uow = new UnitOfWork())
                return uow.Query<Division>().Where(d => d.DivisionKey == divisionKey).Select(d => d.LastReviewCycle).SingleOrDefault();
        }

        public int? GetMaxEmployees(int divisionKey)
        {
            using (var uow = new UnitOfWork())
                return uow.Query<Division>().Where(d => d.DivisionKey == divisionKey).Select(d => d.MaxEmployees).SingleOrDefault();
        }

        public DateTime GetModifiedDate(int divisionKey)
        {
            using (var uow = new UnitOfWork())
                return uow.Query<Division>().Where(d => d.DivisionKey == divisionKey).Select(d => d.ModifiedDate).Single();
        }

        public decimal? GetSalaryBudget(int divisionKey)
        {
            using (var uow = new UnitOfWork())
                return uow.Query<Division>().Where(d => d.DivisionKey == divisionKey).Select(d => d.SalaryBudget).SingleOrDefault();
        }

        public TimeSpan? GetStartTime(int divisionKey)
        {
            using (var uow = new UnitOfWork())
                return uow.Query<Division>().Where(d => d.DivisionKey == divisionKey).Select(d => d.StartTime).SingleOrDefault();
        }
    }
}
