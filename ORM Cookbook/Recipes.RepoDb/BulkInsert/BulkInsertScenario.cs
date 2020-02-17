using Microsoft.Data.SqlClient;
using Recipes.BulkInsert;
using Recipes.RepoDb.Models;
using RepoDb;
using System;
using System.Collections.Generic;
using System.Data;

namespace Recipes.RepoDb.BulkInsert
{
    public class BulkInsertScenario : DbRepository<SqlConnection>,
        IBulkInsertScenario<EmployeeSimple>
    {
        public BulkInsertScenario(string connectionString) : base(connectionString)
        { }

        public int CountByLastName(string lastName)
        {
            return (int)Count<EmployeeSimple>(e => e.LastName == lastName);
        }

        public void BulkInsert(IList<EmployeeSimple> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            this.BulkInsert<EmployeeSimple>(employees);
        }

        public void BulkInsert(DataTable employees)
        {
            if (employees == null)
                throw new ArgumentNullException(nameof(employees), $"{nameof(employees)} is null.");

            this.BulkInsert<EmployeeSimple>(employees, rowState: DataRowState.Added);
        }
    }
}
