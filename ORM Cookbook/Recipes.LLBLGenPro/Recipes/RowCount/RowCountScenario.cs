using Recipes.RowCount;
using System;
using System.Collections.Generic;
using System.Linq;
using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using LLBLGenPro.OrmCookbook.FactoryClasses;
using LLBLGenPro.OrmCookbook.HelperClasses;
using LLBLGenPro.OrmCookbook.Linq;
using SD.LLBLGen.Pro.QuerySpec;
using SD.LLBLGen.Pro.QuerySpec.Adapter;

namespace Recipes.LLBLGenPro.RowCount
{
	public class RowCountScenario : IRowCountScenario<EmployeeEntity>
	{
		public int EmployeeCount(string lastName)
		{
			using(var adapter = new DataAccessAdapter())
			{
				return new LinqMetaData(adapter).Employee.Count(e => e.LastName == lastName);
			}
		}


		public int EmployeeCount()
		{
			using(var adapter = new DataAccessAdapter())
			{
				// Use queryspec for a change... 
				return adapter.FetchScalar<int>(new QueryFactory().Employee.Select(Functions.CountRow()));
			}
		}


		public void InsertBatch(IList<EmployeeEntity> employees)
		{
			using(var toInsert = new EntityCollection<EmployeeEntity>(employees))
			{
				using(var adapter = new DataAccessAdapter())
				{
					// 0 switches off batching
					adapter.BatchSize = employees?.Count ?? 0;
					adapter.SaveEntityCollection(toInsert);
				}
			}
		}
	}
}