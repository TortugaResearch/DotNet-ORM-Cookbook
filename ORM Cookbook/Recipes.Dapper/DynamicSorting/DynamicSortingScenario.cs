using Dapper;
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

            var sql = new StringBuilder(@"INSERT INTO HR.Employee
(FirstName, MiddleName, LastName, Title, OfficePhone, CellPhone, EmployeeClassificationKey)
VALUES ");
            var parameters = new Dictionary<string, object?>();
            for (var i = 0; i < employees.Count; i++)
            {
                if (i != 0)
                    sql.AppendLine(",");
                sql.Append($"(@FirstName_{i}, @MiddleName_{i}, @LastName_{i}, @Title_{i}, @OfficePhone_{i}, " +
                    $"@CellPhone_{i}, @EmployeeClassificationKey_{i})");

                parameters[$"@FirstName_{i}"] = employees[i].FirstName;
                parameters[$"@MiddleName_{i}"] = employees[i].MiddleName;
                parameters[$"@LastName_{i}"] = employees[i].LastName;
                parameters[$"@Title_{i}"] = employees[i].Title;
                parameters[$"@OfficePhone_{i}"] = employees[i].OfficePhone;
                parameters[$"@CellPhone_{i}"] = employees[i].CellPhone;
                parameters[$"@EmployeeClassificationKey_{i}"] = employees[i].EmployeeClassificationKey;
            }
            sql.AppendLine(";");

            //No transaction is needed because a single SQL statement is used.
            using (var con = OpenConnection())
                con.Execute(sql.ToString(), parameters);
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
