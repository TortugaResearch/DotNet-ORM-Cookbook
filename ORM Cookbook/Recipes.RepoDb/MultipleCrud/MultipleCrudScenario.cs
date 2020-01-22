using Recipes.RepoDb.Models;
using Recipes.MultipleCrud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using RepoDb;
using ORepoDb = RepoDb;
using RepoDb.Extensions;

namespace Recipes.Ado.MultipleCrud
{
    public class MultipleCrudScenario : DbRepository<SqlConnection>,
        IMultipleCrudScenario<EmployeeSimple>
    {
        public MultipleCrudScenario(string connectionString)
            : base(connectionString, ORepoDb.Enumerations.ConnectionPersistency.Instance)
        { }

        public void DeleteBatch(IList<EmployeeSimple> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            var keys = employees.Select(e => e.EmployeeKey).AsList();
            Delete<EmployeeSimple>(e => keys.Contains(e.EmployeeKey));
        }

        public void DeleteBatchByKey(IList<int> employeeKeys)
        {
            if (employeeKeys == null || employeeKeys.Count == 0)
                throw new ArgumentException($"{nameof(employeeKeys)} is null or empty.", nameof(employeeKeys));

            Delete<EmployeeSimple>(e => employeeKeys.Contains(e.EmployeeKey));
        }

        public IList<EmployeeSimple> FindByLastName(string lastName)
        {
            return Query<EmployeeSimple>(e => e.LastName == lastName).AsList();
        }

        public void InsertBatch(IList<EmployeeSimple> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            InsertAll(employees);
        }

        public IList<int> InsertBatchReturnKeys(IList<EmployeeSimple> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            InsertAll(employees);

            return employees.Select(e => e.EmployeeKey).AsList();
        }

        public IList<EmployeeSimple> InsertBatchReturnRows(IList<EmployeeSimple> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            InsertAll(employees);

            return employees;
        }

        public void InsertBatchWithRefresh(IList<EmployeeSimple> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            // TODO: Can you review this? What is the intention of this 'WithRefresh()'?
            InsertAll(employees);
        }

        public void UpdateBatch(IList<EmployeeSimple> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            UpdateAll(employees);
        }
    }
}
