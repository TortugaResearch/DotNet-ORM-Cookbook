using LinqToDB;
using Recipes.LinqToDB.Entities;
using Recipes.Upsert;
using System;
using System.Linq;

namespace Recipes.LinqToDB.Upsert
{
    public class UpsertScenario : IUpsertScenario<Division>
    {
        public Division GetByKey(int divisionKey)
        {
            using (var db = new OrmCookbook())
                return db.Division.Where(d => d.DivisionKey == divisionKey).Single();
        }

        public int UpsertByName(Division division)
        {
            if (division == null)
                throw new ArgumentNullException(nameof(division), $"{nameof(division)} is null.");

            //update audit column
            division.CreatedDate = DateTime.UtcNow;
            division.ModifiedDate = DateTime.UtcNow;

            using (var db = new OrmCookbook())
            {
                //check to see if the row already exists
                var actual = db.Division.Where(x => x.DivisionName == division.DivisionName).SingleOrDefault();
                if (actual == null) //Insert
                {
                    return db.InsertWithInt32Identity(division);
                }
                else //Update
                {
                    //Set fields manually so we don't overwrite CreatedBy/CreatedDate
                    db.Division
                        .Where(d => d.DivisionKey == actual.DivisionKey)
                        .Set(d => d.DivisionId, division.DivisionId)
                        .Set(d => d.DivisionName, division.DivisionName)
                        .Set(d => d.FloorSpaceBudget, division.FloorSpaceBudget)
                        .Set(d => d.FteBudget, division.FteBudget)
                        .Set(d => d.LastReviewCycle, division.LastReviewCycle)
                        .Set(d => d.MaxEmployees, division.MaxEmployees)
                        .Set(d => d.ModifiedByEmployeeKey, division.ModifiedByEmployeeKey)
                        .Set(d => d.ModifiedDate, division.ModifiedDate)
                        .Set(d => d.SalaryBudget, division.SalaryBudget)
                        .Set(d => d.StartTime, division.StartTime)
                        .Set(d => d.SuppliesBudget, division.SuppliesBudget)
                        .Update();

                    return actual.DivisionKey;
                }
            }
        }

        public int UpsertByPrimaryKey(Division division)
        {
            if (division == null)
                throw new ArgumentNullException(nameof(division), $"{nameof(division)} is null.");

            //update audit column
            division.CreatedDate = DateTime.UtcNow;
            division.ModifiedDate = DateTime.UtcNow;

            using (var db = new OrmCookbook())
            {
                //If DivisionKey is zero, we know this is a new row
                if (division.DivisionKey == 0) //Insert
                {
                    return db.InsertWithInt32Identity(division);
                }
                else //Update
                {
                    //This wouldn't be necessary if we were replacing all columns.
                    var actual = db.Division.Where(x => x.DivisionKey == division.DivisionKey).Single();

                    //Set fields manually so we don't overwrite CreatedBy/CreatedDate
                    db.Division
                        .Where(d => d.DivisionKey == actual.DivisionKey)
                        .Set(d => d.DivisionId, division.DivisionId)
                        .Set(d => d.DivisionName, division.DivisionName)
                        .Set(d => d.FloorSpaceBudget, division.FloorSpaceBudget)
                        .Set(d => d.FteBudget, division.FteBudget)
                        .Set(d => d.LastReviewCycle, division.LastReviewCycle)
                        .Set(d => d.MaxEmployees, division.MaxEmployees)
                        .Set(d => d.ModifiedByEmployeeKey, division.ModifiedByEmployeeKey)
                        .Set(d => d.ModifiedDate, division.ModifiedDate)
                        .Set(d => d.SalaryBudget, division.SalaryBudget)
                        .Set(d => d.StartTime, division.StartTime)
                        .Set(d => d.SuppliesBudget, division.SuppliesBudget)
                        .Update();

                    return actual.DivisionKey;
                }
            }
        }
    }
}
