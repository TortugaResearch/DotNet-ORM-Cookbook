using Recipes.Pagination;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using LLBLGenPro.OrmCookbook.HelperClasses;
using LLBLGenPro.OrmCookbook.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;

namespace Recipes.LLBLGenPro.Pagination
{
	public class PaginationScenario : IPaginationScenario<EmployeeEntity>
	{
		public void InsertBatch(IList<EmployeeEntity> employees)
		{
			using(var toInsert = new EntityCollection<EmployeeEntity>(employees))
			{
				using(var adapter = new DataAccessAdapter())
				{
					adapter.BatchSize = employees?.Count ?? 0;
					adapter.SaveEntityCollection(toInsert);
				}
			}
		}


		public IList<EmployeeEntity> PaginateWithPageSize(string lastName, int page, int pageSize)
		{
			using(var adapter = new DataAccessAdapter())
			{
				// we pass in page+1, as the tests start paging at page 0, but in LLBLGen Pro, a page number 0
				// means paging isn't used.
				return new LinqMetaData(adapter).Employee.Where(e => e.LastName == lastName)
												.OrderBy(e => e.FirstName).ThenBy(e => e.EmployeeKey)
												.TakePage(page + 1, pageSize).ToList();
			}
		}


		[SuppressMessage("Globalization", "CA1307")]
		public IList<EmployeeEntity> PaginateWithSkipPast(string lastName, EmployeeEntity? skipPast, int take)
		{
			using(var adapter = new DataAccessAdapter())
			{
				if(skipPast == null)
				{
					return new LinqMetaData(adapter).Employee.Where(e => e.LastName == lastName)
													.OrderBy(e => e.FirstName).ThenBy(e => e.EmployeeKey)
													.Take(take).ToList();
				}

				return new LinqMetaData(adapter).Employee
												.Where(e => (e.LastName == lastName) && (
																(string.Compare(e.FirstName, skipPast.FirstName) > 0)
																|| (e.FirstName == skipPast.FirstName && e.EmployeeKey > skipPast.EmployeeKey))
													  )
												.OrderBy(e => e.FirstName).ThenBy(e => e.EmployeeKey)
												.Take(take).ToList();
			}
		}


		public IList<EmployeeEntity> PaginateWithSkipTake(string lastName, int skip, int take)
		{
			using(var adapter = new DataAccessAdapter())
			{
				return new LinqMetaData(adapter).Employee.Where(e => e.LastName == lastName)
												.OrderBy(e => e.FirstName).ThenBy(e => e.EmployeeKey)
												.Skip(skip).Take(take).ToList();
			}
		}
	}
}