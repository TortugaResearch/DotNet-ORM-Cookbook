using Microsoft.Data.SqlClient;
using Recipes.MultipleCrud;
using Recipes.RepoDb.Models;
using RepoDb;
using RepoDb.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

using RDB = RepoDb;

namespace Recipes.RepoDb.MultipleCrud
{
    public class MultipleCrudScenario : BaseRepository<EmployeeSimple, SqlConnection>,
        IMultipleCrudScenario<EmployeeSimple>
    {
        public MultipleCrudScenario(string connectionString)
            : base(connectionString, RDB.Enumerations.ConnectionPersistency.Instance)
        { }

        public void DeleteBatch(IList<EmployeeSimple> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            var keys = employees.Select(e => e.EmployeeKey).AsList();
            Delete(e => keys.Contains(e.EmployeeKey));
        }

        public void DeleteBatchByKey(IList<int> employeeKeys)
        {
            if (employeeKeys == null || employeeKeys.Count == 0)
                throw new ArgumentException($"{nameof(employeeKeys)} is null or empty.", nameof(employeeKeys));

            Delete(e => employeeKeys.Contains(e.EmployeeKey));
        }

        public IList<EmployeeSimple> FindByLastName(string lastName)
        {
            return Query(e => e.LastName == lastName).AsList();
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
