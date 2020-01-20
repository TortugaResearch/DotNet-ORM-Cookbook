using Recipes.MultipleCrud;
using System;
using System.Collections.Generic;
using System.Linq;
using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using LLBLGenPro.OrmCookbook.HelperClasses;
using LLBLGenPro.OrmCookbook.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.QuerySpec;

namespace Recipes.LLBLGenPro.MultipleCrud
{
	public class MultipleCrudScenario : IMultipleCrudScenario<EmployeeEntity>
	{
		public void DeleteBatch(IList<EmployeeEntity> employees)
		{
			if(employees == null || employees.Count == 0)
				throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

			using(var adapter = new DataAccessAdapter())
			{
				// Delete the entities directly using an IN (key1, key2...) predicate. 
				adapter.DeleteEntitiesDirectly(typeof(EmployeeEntity),
											   new RelationPredicateBucket(EmployeeFields.EmployeeKey
																						 .In(employees.Select(e => e.EmployeeKey).ToList())));
			}
		}


		public void DeleteBatchByKey(IList<int> employeeKeys)
		{
			if(employeeKeys == null || employeeKeys.Count == 0)
				throw new ArgumentException($"{nameof(employeeKeys)} is null or empty.", nameof(employeeKeys));
			
			using(var adapter = new DataAccessAdapter())
			{
				// Delete the entities directly using an IN (key1, key2...) predicate. 
				adapter.DeleteEntitiesDirectly(typeof(EmployeeEntity),
											   new RelationPredicateBucket(EmployeeFields.EmployeeKey.In(employeeKeys)));
			}
		}


		public IList<EmployeeEntity> FindByLastName(string lastName)
		{
			using(var adapter = new DataAccessAdapter())
			{
				return new LinqMetaData(adapter).Employee.Where(e => e.LastName == lastName).ToList();
			}
		}


		public void InsertBatch(IList<EmployeeEntity> employees)
		{
			if(employees == null || employees.Count == 0)
				throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

			// The collection is disposed as it assigns event handlers to the entities it contains. Keeping the
			// entities around would keep the collection in memory.
			using(var toInsert = new EntityCollection<EmployeeEntity>(employees))
			{
				using(var adapter = new DataAccessAdapter())
				{
					// use batching for inserts. We'll use 100 for a batch size here. 
					// This will send at most 100 inserts at one time to the database
					// in a single DbCommand
					adapter.BatchSize = 100;
					adapter.SaveEntityCollection(toInsert);
				}
			}
		}


		public IList<int> InsertBatchReturnKeys(IList<EmployeeEntity> employees)
		{
			if(employees == null || employees.Count == 0)
				throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

			using(var toInsert = new EntityCollection<EmployeeEntity>(employees))
			{
				using(var adapter = new DataAccessAdapter())
				{
					// use batching for inserts. We'll use 100 for a batch size here. 
					// This will send at most 100 inserts at one time to the database
					// in a single DbCommand
					adapter.BatchSize = 100;
					adapter.SaveEntityCollection(toInsert);
				}

				return toInsert.Select(e => e.EmployeeKey).ToList();
			}
		}


		public IList<EmployeeEntity> InsertBatchReturnRows(IList<EmployeeEntity> employees)
		{
			if(employees == null || employees.Count == 0)
				throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

			// Use a unit of work here. We could have created a new EntityCollection here but as well
			var uow = new UnitOfWork2();
			foreach(var e in employees)
			{
				uow.AddForSave(e);
			}

			using(var adapter = new DataAccessAdapter())
			{
				// use batching for inserts. We'll use 100 for a batch size here. 
				// This will send at most 100 inserts at one time to the database
				// in a single DbCommand
				adapter.BatchSize = 100;
				uow.Commit(adapter);
			}

			// LLBLGen Pro will update entities in-place after an insert, so we can return what we received. 
			return employees;
		}


		public void InsertBatchWithRefresh(IList<EmployeeEntity> employees)
		{
			if(employees == null || employees.Count == 0)
				throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

			using(var toInsert = new EntityCollection<EmployeeEntity>(employees))
			{
				using(var adapter = new DataAccessAdapter())
				{
					// use batching for inserts. We'll use 100 for a batch size here. 
					// This will send at most 100 inserts at one time to the database
					// in a single DbCommand. LLBLGen Pro will update the entity saved
					// with the new PK.
					adapter.BatchSize = 100;
					adapter.SaveEntityCollection(toInsert);
				}
			}
		}


		public void UpdateBatch(IList<EmployeeEntity> employees)
		{
			if(employees == null || employees.Count == 0)
				throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

			using(var toUpdate = new EntityCollection<EmployeeEntity>(employees))
			{
				using(var adapter = new DataAccessAdapter())
				{
					// use batching for updates. We'll use 100 for a batch size here. 
					// This will send at most 100 updates at one time to the database
					// in a single DbCommand
					adapter.BatchSize = 100;
					adapter.SaveEntityCollection(toUpdate);
				}
			}
		}
	}
}