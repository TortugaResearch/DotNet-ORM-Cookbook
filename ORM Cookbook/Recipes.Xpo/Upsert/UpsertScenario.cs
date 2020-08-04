using Recipes.Xpo.Entities;
using Recipes.Upsert;
using System;
using System.Linq;
using DevExpress.Xpo;

namespace Recipes.Xpo.Upsert
{
    public class UpsertScenario : IUpsertScenario<Division>
    {

        public Division GetByKey(int divisionKey)
        {
            return Session.DefaultSession.GetObjectByKey<Division>(divisionKey);
        }

        public int UpsertByName(Division division)
        {
            if (division == null)
                throw new ArgumentNullException(nameof(division), $"{nameof(division)} is null.");

            //update audit column
            division.CreatedDate = DateTime.UtcNow;
            division.ModifiedDate = DateTime.UtcNow;

            //check to see if the row already exists
            var actual = Session.DefaultSession.Query<Division>().Where(x => x.DivisionName == division.DivisionName).SingleOrDefault();
            if (actual == null) //Insert
            {
                division.Save();
                return division.DivisionKey;
            } else //Update
            {
                //Copy manually so we don't overwrite CreatedBy/CreatedDate
                actual.DivisionId = division.DivisionId;
                actual.DivisionName = division.DivisionName;
                actual.FloorSpaceBudget = division.FloorSpaceBudget;
                actual.FteBudget = division.FteBudget;
                actual.LastReviewCycle = division.LastReviewCycle;
                actual.MaxEmployees = division.MaxEmployees;
                actual.ModifiedByEmployee = division.ModifiedByEmployee;
                actual.ModifiedDate = division.ModifiedDate;
                actual.SalaryBudget = division.SalaryBudget;
                actual.StartTime = division.StartTime;
                actual.SuppliesBudget = division.SuppliesBudget;
                actual.Save();
                return actual.DivisionKey;
            }
        }

        public int UpsertByPrimaryKey(Division division)
        {
            if (division == null)
                throw new ArgumentNullException(nameof(division), $"{nameof(division)} is null.");

            //update audit column
            division.CreatedDate = DateTime.UtcNow;
            division.ModifiedDate = DateTime.UtcNow;

            //If DivisionKey is zero, we know this is a new row
            if (division.DivisionKey == 0) //Insert
            {
                division.Save();
                return division.DivisionKey;
            } else //Update
            {
                //This wouldn't be necessary if we were replacing all columns.
                var actual = Session.DefaultSession.GetObjectByKey<Division>(division.DivisionKey);

                //Copy manually so we don't overwrite CreatedBy/CreatedDate
                actual.DivisionId = division.DivisionId;
                actual.DivisionName = division.DivisionName;
                actual.FloorSpaceBudget = division.FloorSpaceBudget;
                actual.FteBudget = division.FteBudget;
                actual.LastReviewCycle = division.LastReviewCycle;
                actual.MaxEmployees = division.MaxEmployees;
                actual.ModifiedByEmployee = division.ModifiedByEmployee;
                actual.ModifiedDate = division.ModifiedDate;
                actual.SalaryBudget = division.SalaryBudget;
                actual.StartTime = division.StartTime;
                actual.SuppliesBudget = division.SuppliesBudget;
                actual.Save();
                return actual.DivisionKey;
            }
        }
    }
}
