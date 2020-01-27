using Dapper;
using Recipes.Dapper.Models;
using Recipes.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recipes.Dapper.Sorting
{
    public class SortingScenario : ScenarioBase, ISortingScenario<EmployeeSimple>
    {
        public SortingScenario(string connectionString) : base(connectionString)
        {
        }

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
                sql.Append($"(@FirstName_{i}, @MiddleName_{i}, @LastName_{i}, @Title_{i}, @OfficePhone_{i}, @CellPhone_{i}, @EmployeeClassificationKey_{i})");

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

        public IList<EmployeeSimple> SortByFirstName(string lastName)
        {
            const string sql = "SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, e.CellPhone, e.EmployeeClassificationKey FROM HR.Employee e WHERE e.LastName = @LastName ORDER BY e.FirstName";

            using (var con = OpenConnection())
                return con.Query<EmployeeSimple>(sql, new { lastName }).ToList();
        }

        public IList<EmployeeSimple> SortByMiddleNameDescFirstName(string lastName)
        {
            const string sql = "SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, e.CellPhone, e.EmployeeClassificationKey FROM HR.Employee e WHERE e.LastName = @LastName ORDER BY e.MiddleName DESC, e.FirstName";

            using (var con = OpenConnection())
                return con.Query<EmployeeSimple>(sql, new { lastName }).ToList();
        }

        public IList<EmployeeSimple> SortByMiddleNameFirstName(string lastName)
        {
            const string sql = "SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, e.CellPhone, e.EmployeeClassificationKey FROM HR.Employee e WHERE e.LastName = @LastName ORDER BY e.MiddleName, e.FirstName";

            using (var con = OpenConnection())
                return con.Query<EmployeeSimple>(sql, new { lastName }).ToList();
        }
    }
}
