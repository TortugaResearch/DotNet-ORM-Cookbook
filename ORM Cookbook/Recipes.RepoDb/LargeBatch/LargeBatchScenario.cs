using Recipes.LargeBatch;
using Recipes.RepoDb.Models;
using RepoDb;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

using RDB = RepoDb;

namespace Recipes.RepoDb.LargeBatch
{
    public class LargeBatchScenario : BaseRepository<EmployeeSimple, SqlConnection>, ILargeBatchScenario<EmployeeSimple>
    {
        public LargeBatchScenario(string connectionString)
            : base(connectionString, RDB.Enumerations.ConnectionPersistency.Instance)
        { }

        public int CountByLastName(string lastName)
        {
            return Query(e => e.LastName == lastName).Count();
        }

        public int MaximumBatchSize => 2100 / 7;

        public void InsertLargeBatch(IList<EmployeeSimple> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            InsertAll(employees);
        }

        public void InsertLargeBatch(IList<EmployeeSimple> employees, int batchSize)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            InsertAll(employees, batchSize: batchSize);
        }
    }
}
