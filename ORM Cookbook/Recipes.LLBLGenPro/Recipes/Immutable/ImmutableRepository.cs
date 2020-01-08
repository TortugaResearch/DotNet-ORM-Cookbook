using Recipes.Immutable;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Linq;
using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using LLBLGenPro.OrmCookbook.HelperClasses;
using LLBLGenPro.OrmCookbook.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.QuerySpec;

namespace Recipes.LLBLGenPro.Immutable
{
	public class ImmutableRepository : IImmutableRepository<ReadOnlyEmployeeClassification>
	{
		public int Create(ReadOnlyEmployeeClassification classification)
		{
			if (classification == null)
				throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

			using (var adapter = new DataAccessAdapter())
			{
				var temp = classification.ToEntity();
				adapter.SaveEntity(temp);
				return temp.EmployeeClassificationKey;
			}
		}

		public virtual void DeleteByKey(int employeeClassificationKey)
		{
			using (var adapter = new DataAccessAdapter())
			{
				adapter.DeleteEntitiesDirectly(typeof(EmployeeClassificationEntity),
											   new RelationPredicateBucket(EmployeeClassificationFields.EmployeeClassificationKey.Equal(employeeClassificationKey)));
			}
		}

		public virtual void Delete(ReadOnlyEmployeeClassification classification)
		{
			if (classification == null)
				throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

			DeleteByKey(classification.EmployeeClassificationKey);
		}

		public ReadOnlyEmployeeClassification? FindByName(string employeeClassificationName)
		{
			using (var adapter = new DataAccessAdapter())
			{
				return new LinqMetaData(adapter).EmployeeClassification
					.Where(ec => ec.EmployeeClassificationName == employeeClassificationName)
					.Select(x => new ReadOnlyEmployeeClassification(x)).SingleOrDefault();
			}
		}

		public IReadOnlyList<ReadOnlyEmployeeClassification> GetAll()
		{
			using (var adapter = new DataAccessAdapter())
			{
				return new LinqMetaData(adapter).EmployeeClassification.Select(x => new ReadOnlyEmployeeClassification(x)).ToImmutableArray();
			}
		}

		public ReadOnlyEmployeeClassification GetByKey(int employeeClassificationKey)
		{
			using (var adapter = new DataAccessAdapter())
			{
				var temp = adapter.FetchNewEntity<EmployeeClassificationEntity>(new RelationPredicateBucket(EmployeeClassificationFields.EmployeeClassificationKey.Equal(employeeClassificationKey)));
				if (temp.IsNew)
					throw new DataException($"No row was found for key {employeeClassificationKey}.");
				return new ReadOnlyEmployeeClassification(temp);
			}
		}

		public void Update(ReadOnlyEmployeeClassification classification)
		{
			if (classification == null)
				throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

			using (var adapter = new DataAccessAdapter())
			{
				//Get a fresh copy of the row from the database
				var temp = adapter.FetchNewEntity<EmployeeClassificationEntity>(
									new RelationPredicateBucket(EmployeeClassificationFields.EmployeeClassificationKey.Equal(classification.EmployeeClassificationKey)));
				if (!temp.IsNew)
				{
					//Copy the changed fields
					temp.EmployeeClassificationName = classification.EmployeeClassificationName;
					temp.IsEmployee = classification.IsEmployee;
					temp.IsExempt = classification.IsExempt;
					adapter.SaveEntity(temp);
				}
			}
		}
	}
}
