using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Recipes.Dapper.Models;
using Recipes.DynamicSorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recipes.Dapper.DynamicSorting
{
    public class DynamicSortingScenario : ScenarioBase, IDynamicSortingScenario<EmployeeSimple>
    {
        public DynamicSortingScenario(string connectionString) : base(connectionString)
        { }

        public void InsertBatch(IList<EmployeeSimple> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            using (var con = OpenConnection())
                con.Insert(employees);
        }

        public IList<EmployeeSimple> SortBy(string lastName, string sortByColumn, bool isDescending)
        {
            if (!Utilities.EmployeeColumnNames.Contains(sortByColumn))
                throw new ArgumentOutOfRangeException(nameof(sortByColumn), "Unknown column " + sortByColumn);

            var sortDirection = isDescending ? "DESC " : "";

            var sql = "SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, " +
                "e.CellPhone, e.EmployeeClassificationKey FROM HR.Employee e WHERE e.LastName = @LastName " +
                $"ORDER BY [{sortByColumn}] {sortDirection}";

            using (var con = OpenConnection())
                return con.Query<EmployeeSimple>(sql, new { lastName }).ToList();
        }

        public IList<EmployeeSimple> SortBy(string lastName, string sortByColumnA, bool isDescendingA,
            string sortByColumnB, bool isDescendingB)
        {
            if (!Utilities.EmployeeColumnNames.Contains(sortByColumnA))
                throw new ArgumentOutOfRangeException(nameof(sortByColumnA), "Unknown column " + sortByColumnA);
            if (!Utilities.EmployeeColumnNames.Contains(sortByColumnB))
                throw new ArgumentOutOfRangeException(nameof(sortByColumnB), "Unknown column " + sortByColumnB);

            var sortDirectionA = isDescendingA ? "DESC " : "";
            var sortDirectionB = isDescendingB ? "DESC " : "";

            var sql = "SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, " +
                "e.CellPhone, e.EmployeeClassificationKey FROM HR.Employee e WHERE e.LastName = @LastName " +
                $"ORDER BY [{sortByColumnA}] {sortDirectionA}, [{sortByColumnB}] {sortDirectionB}";

            using (var con = OpenConnection())
                return con.Query<EmployeeSimple>(sql, new { lastName }).ToList();
        }
    }
}
