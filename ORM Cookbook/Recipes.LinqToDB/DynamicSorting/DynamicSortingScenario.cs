using LinqToDB;
using LinqToDB.Data;
using Recipes.DynamicSorting;
using Recipes.LinqToDB.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.LinqToDB.DynamicSorting
{
    public class DynamicSortingScenario : IDynamicSortingScenario<Employee>
    {
        public void InsertBatch(IList<Employee> employees)
        {
            var options = new BulkCopyOptions() { BulkCopyType = BulkCopyType.MultipleRows };
            using (var db = new OrmCookbook())
                db.BulkCopy(options, employees);
        }

        public IList<Employee> SortBy(string lastName, string sortByColumn, bool isDescending)
        {
            using (var db = new OrmCookbook())
                return db.Employee.Where(x => x.LastName == lastName)
                    .OrderBy(sortByColumn, isDescending).ToList();
        }

        public IList<Employee> SortBy(string lastName, string sortByColumnA, bool isDescendingA,
            string sortByColumnB, bool isDescendingB)
        {
            using (var db = new OrmCookbook())
                return db.Employee.Where(x => x.LastName == lastName)
                    .OrderBy(sortByColumnA, isDescendingA)
                    .ThenBy(sortByColumnB, isDescendingB)
                    .ToList();
        }
    }
}
