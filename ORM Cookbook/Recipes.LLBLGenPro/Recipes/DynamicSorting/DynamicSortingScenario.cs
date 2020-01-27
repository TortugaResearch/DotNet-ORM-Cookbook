using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using LLBLGenPro.OrmCookbook.HelperClasses;
using LLBLGenPro.OrmCookbook.Linq;
using Recipes.DynamicSorting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.LLBLGenPro.DynamicSorting
{
    public class DynamicSortingScenario : IDynamicSortingScenario<EmployeeEntity>
    {
        public void InsertBatch(IList<EmployeeEntity> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            using (var toInsert = new EntityCollection<EmployeeEntity>(employees))
            {
                using (var adapter = new DataAccessAdapter())
                {
                    adapter.BatchSize = 100;
                    adapter.SaveEntityCollection(toInsert);
                }
            }
        }

        public IList<EmployeeEntity> SortBy(string lastName, string sortByColumn, bool isDescending)
        {
            using (var adapter = new DataAccessAdapter())
			{
				return new LinqMetaData(adapter).Employee.Where(x => x.LastName == lastName)
												.OrderBy(sortByColumn, isDescending)
												.ToList();
			}
        }

        public IList<EmployeeEntity> SortBy(string lastName, string sortByColumnA, bool isDescendingA,
            string sortByColumnB, bool isDescendingB)
        {
            using (var adapter = new DataAccessAdapter())
			{
				return new LinqMetaData(adapter).Employee.Where(x => x.LastName == lastName)
												.OrderBy(sortByColumnA, isDescendingA)
												.ThenBy(sortByColumnB, isDescendingB)
												.ToList();
			}
        }
    }
}
