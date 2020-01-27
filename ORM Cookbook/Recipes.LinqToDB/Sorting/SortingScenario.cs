using LinqToDB;
using LinqToDB.Data;
using Recipes.LinqToDB.Entities;
using Recipes.Sorting;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.LinqToDB.Sorting
{
    public class SortingScenario : ISortingScenario<Employee>
    {
        public void InsertBatch(IList<Employee> employees)
        {
            var options = new BulkCopyOptions() { BulkCopyType = BulkCopyType.MultipleRows };
            using (var db = new OrmCookbook())
                db.BulkCopy(options, employees);
        }

        public IList<Employee> SortByFirstName(string lastName)
        {
            using (var db = new OrmCookbook())
                return db.Employee.Where(x => x.LastName == lastName)
                    .OrderBy(x => x.FirstName).ToList();
        }

        public IList<Employee> SortByMiddleNameDescFirstName(string lastName)
        {
            using (var db = new OrmCookbook())
                return db.Employee.Where(x => x.LastName == lastName)
                    .OrderByDescending(x => x.MiddleName).ThenBy(x => x.FirstName).ToList();
        }

        public IList<Employee> SortByMiddleNameFirstName(string lastName)
        {
            using (var db = new OrmCookbook())
                return db.Employee.Where(x => x.LastName == lastName)
                    .OrderBy(x => x.MiddleName).ThenBy(x => x.FirstName).ToList();
        }
    }
}
