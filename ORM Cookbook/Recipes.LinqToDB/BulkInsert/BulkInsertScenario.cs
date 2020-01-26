using LinqToDB.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.BulkInsert;
using Recipes.LinqToDB.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Recipes.LinqToDB.BulkInsert
{
    public class BulkInsertScenario : IBulkInsertScenario<Employee>
    {
        public void BulkInsert(IList<Employee> employees)
        {
            var options = new BulkCopyOptions() { BulkCopyType = BulkCopyType.ProviderSpecific };
            using (var db = new OrmCookbook())
                db.BulkCopy(options, employees);
        }

        public void BulkInsert(DataTable employees)
        {
            Assert.Inconclusive("Bulk insert using a DataTable is not supported.");
        }

        public int CountByLastName(string lastName)
        {
            using (var db = new OrmCookbook())
                return db.Employee.Where(x => x.LastName == lastName).Count();
        }
    }
}
