using LinqToDB.Data;
using Recipes.LargeBatch;
using Recipes.LinqToDB.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Recipes.LinqToDB.LargeBatch
{
    public class LargeBatchScenario : ILargeBatchScenario<Employee>
    {
        public int MaximumBatchSize => int.MaxValue;

        public int CountByLastName(string lastName)
        {
            using (var db = new OrmCookbook())
                return db.Employee.Where(x => x.LastName == lastName).Count();
        }

        public void InsertLargeBatch(IList<Employee> employees)
        {
            var options = new BulkCopyOptions() { BulkCopyType = BulkCopyType.MultipleRows };
            using (var db = new OrmCookbook())
                db.BulkCopy(options, employees);
        }

        public void InsertLargeBatch(IList<Employee> employees, int batchSize)
        {
            var options = new BulkCopyOptions()
            {
                BulkCopyType = BulkCopyType.MultipleRows,
                MaxBatchSize = batchSize
            };

            using (var db = new OrmCookbook())
                db.BulkCopy(options, employees);
        }
    }
}
