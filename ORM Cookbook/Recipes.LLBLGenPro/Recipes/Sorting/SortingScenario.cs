using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using LLBLGenPro.OrmCookbook.HelperClasses;
using LLBLGenPro.OrmCookbook.Linq;
using Recipes.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.LLBLGenPro.Sorting
{
	public class SortingScenario : ISortingScenario<EmployeeEntity>
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


		public IList<EmployeeEntity> SortByFirstName(string lastName)
		{
			using(var adapter = new DataAccessAdapter())
			{
				return new LinqMetaData(adapter).Employee.Where(x => x.LastName == lastName)
												.OrderBy(x => x.FirstName)
												.ToList();
			}
		}


		public IList<EmployeeEntity> SortByMiddleNameDescFirstName(string lastName)

		{
			using(var adapter = new DataAccessAdapter())
			{
				return new LinqMetaData(adapter).Employee.Where(x => x.LastName == lastName)
												.OrderByDescending(x => x.MiddleName)
												.ThenBy(x => x.FirstName)
												.ToList();
			}
		}


		public IList<EmployeeEntity> SortByMiddleNameFirstName(string lastName)
		{
			using(var adapter = new DataAccessAdapter())
			{
				return new LinqMetaData(adapter).Employee
												.Where(x => x.LastName == lastName)
												.OrderBy(x => x.MiddleName).ThenBy(x => x.FirstName)
												.ToList();
			}
		}
	}
}