using Recipes.RepoDb.Models;
using Recipes.RowCount;
using RepoDb;
using RDB = RepoDb;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Recipes.RepoDb.RowCount
{
    public class RowCountScenario : DbRepository<SqlConnection>,
        IRowCountScenario<EmployeeSimple>
    {
        public RowCountScenario(string connectionString)
            : base(connectionString, RDB.Enumerations.ConnectionPersistency.Instance)
        { }

        public int EmployeeCount(string lastName)
        {
            return (int)Count<EmployeeSimple>(e => e.LastName == lastName);
        }

        public int EmployeeCount()
        {
            return (int)CountAll<EmployeeSimple>();
        }

        public void InsertBatch(IList<EmployeeSimple> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            InsertAll(employees);
        }
    }
}
