using Microsoft.Data.SqlClient;
using Recipes.Ado.Models;
using Recipes.Sorting;
using System;
using System.Collections.Generic;

namespace Recipes.Ado.Sorting
{
    public class SortingScenario : ScenarioBase, ISortingScenario<EmployeeSimple>
    {
        public SortingScenario(string connectionString) : base(connectionString)
        { }

        public int Create(EmployeeSimple employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

            const string sql = @"INSERT INTO HR.Employee
(FirstName, MiddleName, LastName, Title, OfficePhone, CellPhone, EmployeeClassificationKey)
OUTPUT Inserted.EmployeeKey
VALUES
(@FirstName, @MiddleName, @LastName, @Title, @OfficePhone, @CellPhone, @EmployeeClassificationKey);";

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", (object?)employee.MiddleName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                cmd.Parameters.AddWithValue("@Title", (object?)employee.Title ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@OfficePhone", (object?)employee.OfficePhone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CellPhone", (object?)employee.CellPhone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@EmployeeClassificationKey", employee.EmployeeClassificationKey);

                return (int)cmd.ExecuteScalar();
            }
        }

        public IList<EmployeeSimple> SortByLastName()
        {
            const string sql = "SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, e.CellPhone, e.EmployeeClassificationKey FROM HR.Employee e ORDER BY e.LastName";

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                var results = new List<EmployeeSimple>();

                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        results.Add(new EmployeeSimple(reader));

                return results;
            }
        }

        public IList<EmployeeSimple> SortByLastNameDescFirstName()
        {
            const string sql = "SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, e.CellPhone, e.EmployeeClassificationKey FROM HR.Employee e ORDER BY e.LastName DESC, e.FirstName";

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                var results = new List<EmployeeSimple>();

                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        results.Add(new EmployeeSimple(reader));

                return results;
            }
        }

        public IList<EmployeeSimple> SortByLastNameFirstName()
        {
            const string sql = "SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, e.CellPhone, e.EmployeeClassificationKey FROM HR.Employee e ORDER BY e.LastName, e.FirstName";

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                var results = new List<EmployeeSimple>();

                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        results.Add(new EmployeeSimple(reader));

                return results;
            }
        }
    }
}
