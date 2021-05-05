using Recipes.Upsert;
using System;
using System.Linq;
using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using LLBLGenPro.OrmCookbook.HelperClasses;
using LLBLGenPro.OrmCookbook.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.QuerySpec;

namespace Recipes.LLBLGenPro.Upsert
{
	public class UpsertScenario : IUpsertScenario<DivisionEntity>
	{
		public DivisionEntity? GetByKey(int divisionKey)
		{
			using(var adapter = new DataAccessAdapter())
			{
				return new LinqMetaData(adapter).Division.FirstOrDefault(d => d.DivisionKey == divisionKey);
			}
		}


		public int UpsertByName(DivisionEntity division)
		{
			if(division == null)
				throw new ArgumentNullException(nameof(division), $"{nameof(division)} is null.");

			// LLBLGen Pro doesn't support an atomic upsert statement. Instead we'll simply fetch
			// the entity with the name specified. If it's there, we'll get a filled entity instance
			// which we'll update with the new values (and only the values we then change will be updated
			// in the database), or it'll be a new one, which we'll set to new values and it'll be 
			// inserted. 

			using(var adapter = new DataAccessAdapter())
			{
				var toSave = adapter.FetchNewEntity<DivisionEntity>(
										new RelationPredicateBucket(DivisionFields.DivisionName.Equal(division.DivisionName)));

				// now we'll just set fields and persist it again. If the above fetch returned an existing entity
				// it'll be updated, otherwise it'll be inserted.
				// If the above fetch returned an existing entity, only the fields which changed are updated
				// in the update query.
				toSave.CreatedDate = DateTime.UtcNow;
				toSave.ModifiedDate = DateTime.UtcNow;
				toSave.CreatedByEmployeeKey = division.CreatedByEmployeeKey;
				toSave.ModifiedByEmployeeKey = division.ModifiedByEmployeeKey;
				toSave.DivisionId = division.DivisionId;
				toSave.DivisionName = division.DivisionName;
				toSave.FloorSpaceBudget = division.FloorSpaceBudget;
				toSave.FteBudget = division.FteBudget;
				toSave.LastReviewCycle = division.LastReviewCycle;
				toSave.MaxEmployees = division.MaxEmployees;
				toSave.ModifiedByEmployeeKey = division.ModifiedByEmployeeKey;
				toSave.ModifiedDate = division.ModifiedDate;
				toSave.SalaryBudget = division.SalaryBudget;
				toSave.StartTime = division.StartTime;
				toSave.SuppliesBudget = division.SuppliesBudget;
				adapter.SaveEntity(toSave);
				return toSave.DivisionKey;
			}
		}


		public int UpsertByPrimaryKey(DivisionEntity division)
		{
			if(division == null)
				throw new ArgumentNullException(nameof(division), $"{nameof(division)} is null.");

			// LLBLGen Pro doesn't support an atomic upsert statement. Instead we'll simply fetch
			// the entity with the name specified. If it's there, we'll get a filled entity instance
			// which we'll update with the new values (and only the values we then change will be updated
			// in the database), or it'll be a new one, which we'll set to new values and it'll be 
			// inserted. 

			using(var adapter = new DataAccessAdapter())
			{
				var toSave = adapter.FetchNewEntity<DivisionEntity>(
										new RelationPredicateBucket(DivisionFields.DivisionKey.Equal(division.DivisionKey)));

				// now we'll just set fields and persist it again. If the above fetch returned an existing entity
				// it'll be updated, otherwise it'll be inserted.
				// If the above fetch returned an existing entity, only the fields which changed are updated
				// in the update query.
				toSave.CreatedDate = DateTime.UtcNow;
				toSave.ModifiedDate = DateTime.UtcNow;
				toSave.CreatedByEmployeeKey = division.CreatedByEmployeeKey;
				toSave.ModifiedByEmployeeKey = division.ModifiedByEmployeeKey;
				toSave.DivisionId = division.DivisionId;
				toSave.DivisionName = division.DivisionName;
				toSave.FloorSpaceBudget = division.FloorSpaceBudget;
				toSave.FteBudget = division.FteBudget;
				toSave.LastReviewCycle = division.LastReviewCycle;
				toSave.MaxEmployees = division.MaxEmployees;
				toSave.ModifiedByEmployeeKey = division.ModifiedByEmployeeKey;
				toSave.ModifiedDate = division.ModifiedDate;
				toSave.SalaryBudget = division.SalaryBudget;
				toSave.StartTime = division.StartTime;
				toSave.SuppliesBudget = division.SuppliesBudget;
				adapter.SaveEntity(toSave);
				return toSave.DivisionKey;
			}
		}
	}
}