using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using LLBLGenPro.OrmCookbook.HelperClasses;
using LLBLGenPro.OrmCookbook.Linq;
using Recipes.DynamicSorting;
using System;
using System.Collections.Generic;
using System.Linq;
using LLBLGenPro.OrmCookbook.FactoryClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.QuerySpec;
using SD.LLBLGen.Pro.QuerySpec.Adapter;

namespace Recipes.LLBLGenPro.DynamicSorting
{
	public class DynamicSortingScenario : IDynamicSortingScenario<EmployeeEntity>
	{
		public void InsertBatch(IList<EmployeeEntity> employees)
		{
			if(employees == null || employees.Count == 0)
				throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

			using(var toInsert = new EntityCollection<EmployeeEntity>(employees))
			{
				using(var adapter = new DataAccessAdapter())
				{
					adapter.BatchSize = 100;
					adapter.SaveEntityCollection(toInsert);
				}
			}
		}


		public IList<EmployeeEntity> SortBy(string lastName, string sortByColumn, bool isDescending)
		{
			using(var adapter = new DataAccessAdapter())
			{
				// We use queryspec here which can use the low-level API elements we need to use to accomplish sorting
				// on a string. The low-level API uses entity fields and we obtain the field we need from a dummy entity instance
				// we create. 
				var fieldToSort = new EmployeeEntity().Fields[sortByColumn];
				// fieldToSort will be null if sortByColumn isn't found. The query will therefore end in an exception if that's
				// the case. For this particular test, it's the desired outcome so no null check is performed.
				var q = new QueryFactory().Employee.Where(EmployeeFields.LastName.Equal(lastName))
										  .OrderBy(isDescending
													   ? fieldToSort.Descending()
													   : fieldToSort.Ascending());
				return (IList<EmployeeEntity>)adapter.FetchQuery(q);

				// Alternatively we could have used the DynamicSortingExtensions in a linq query:
				// return new LinqMetaData(adapter).Employee.Where(x => x.LastName == lastName)
				// 								.OrderBy(sortByColumn, isDescending)
				// 								.ToList();
			}
		}


		public IList<EmployeeEntity> SortBy(string lastName, string sortByColumnA, bool isDescendingA,
											string sortByColumnB, bool isDescendingB)
		{
			using(var adapter = new DataAccessAdapter())
			{
				return new LinqMetaData(adapter).Employee.Where(x => x.LastName == lastName)
												.OrderBy(sortByColumnA, isDescendingA)
												.ThenBy(sortByColumnB, isDescendingB)
												.ToList();
			}
		}
	}
}