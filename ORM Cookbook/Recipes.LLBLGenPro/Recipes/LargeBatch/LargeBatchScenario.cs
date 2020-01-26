using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using LLBLGenPro.OrmCookbook.HelperClasses;
using LLBLGenPro.OrmCookbook.Linq;
using Recipes.LargeBatch;
using SD.LLBLGen.Pro.QuerySpec;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.LLBLGenPro.LargeBatch
{
    public class LargeBatchScenario : ILargeBatchScenario<EmployeeEntity>
    {
        public int CountByLastName(string lastName)
        {
            using (var adapter = new DataAccessAdapter())
            {
                return new LinqMetaData(adapter).Employee.Where(e => e.LastName == lastName).Count();
            }
        }

        public int MaximumBatchSize => 2100 / 7;

        public void InsertLargeBatch(IList<EmployeeEntity> employees)
        {
            InsertLargeBatch(employees, 100);
        }

        public void InsertLargeBatch(IList<EmployeeEntity> employees, int batchSize)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            // The collection is disposed as it assigns event handlers to the entities it contains. Keeping the
            // entities around would keep the collection in memory.
            using (var toInsert = new EntityCollection<EmployeeEntity>(employees))
            {
                using (var adapter = new DataAccessAdapter())
                {
                    adapter.BatchSize = batchSize;
                    adapter.SaveEntityCollection(toInsert);
                }
            }
        }
    }
}
