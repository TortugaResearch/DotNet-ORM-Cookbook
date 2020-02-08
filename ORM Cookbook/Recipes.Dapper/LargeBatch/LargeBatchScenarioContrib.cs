using Dapper;
using Recipes.Dapper.Models;
using Recipes.LargeBatch;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;

namespace Recipes.Dapper.LargeBatch
{
    public class LargeBatchScenarioContrib : LargeBatchScenario
    {
        public LargeBatchScenarioContrib(string connectionString) : base(connectionString)
        { }

        override public void InsertLargeBatch(IList<EmployeeSimple> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            using (var con = OpenConnection())
            using (var trans = con.BeginTransaction())
            {
                con.Insert(employees, trans);
                trans.Commit();
            }
        }

        override public void InsertLargeBatch(IList<EmployeeSimple> employees, int batchSize)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            using (var con = OpenConnection())
            using (var trans = con.BeginTransaction())
            {
                foreach (var batch in employees.BatchAsLists(batchSize))
                    con.Insert(batch, trans);

                trans.Commit();
            }
        }
    }
}
