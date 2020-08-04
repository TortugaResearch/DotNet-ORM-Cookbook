using Recipes.Xpo.Entities;
using Recipes.LargeBatch;
using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Xpo;

namespace Recipes.Xpo.LargeBatch
{
    public class LargeBatchScenario : ILargeBatchScenario<Employee>
    {

        public int MaximumBatchSize => int.MaxValue;

        public int CountByLastName(string lastName)
        {
            using (var uow = new UnitOfWork())
                return uow.Query<Employee>().Where(ec => ec.LastName == lastName).Count();
        }

        public void InsertLargeBatch(IList<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            Session.DefaultSession.Save(employees);
        }

        public void InsertLargeBatch(IList<Employee> employees, int batchSize)
        {
            foreach (var batch in employees.BatchAsLists(batchSize))
            {
                Session.DefaultSession.Save(batch);
            }
        }
    }
}
