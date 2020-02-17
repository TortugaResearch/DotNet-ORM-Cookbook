using Microsoft.Data.SqlClient;
using Recipes.Ado.Models;
using Recipes.RowCount;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Ado.RowCount
{
    public class RowCountScenario : SqlServerScenarioBase, IRowCountScenario<EmployeeSimple>
    {
        public RowCountScenario(string connectionString) : base(connectionString)
        { }

        public int EmployeeCount(string lastName)
        {
            const string sql = "SELECT COUNT(*) FROM HR.Employee e WHERE e.LastName = @LastName";
            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@LastName", lastName);
                return (int)cmd.ExecuteScalar();
            }
        }

        public int EmployeeCount()
        {
            const string sql = "SELECT COUNT(*) FROM HR.Employee e";
            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
                return (int)cmd.ExecuteScalar();
        }

        public void InsertBatch(IList<EmployeeSimple> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            var sql = new StringBuilder(@"INSERT INTO HR.Employee
(FirstName, MiddleName, LastName, Title, OfficePhone, CellPhone, EmployeeClassificationKey)
VALUES ");

            for (var i = 0; i < employees.Count; i++)
            {
                if (i != 0)
                    sql.AppendLine(",");
                sql.Append($"(@FirstName_{i}, @MiddleName_{i}, @LastName_{i}, @Title_{i}, @OfficePhone_{i}, @CellPhone_{i}, @EmployeeClassificationKey_{i})");
            }
            sql.AppendLine(";");

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql.ToString(), con))
            {
                for (var i = 0; i < employees.Count; i++)
                {
                    cmd.Parameters.AddWithValue($"@FirstName_{i}", employees[i].FirstName);
                    cmd.Parameters.AddWithValue($"@MiddleName_{i}", (object?)employees[i].MiddleName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue($"@LastName_{i}", employees[i].LastName);
                    cmd.Parameters.AddWithValue($"@Title_{i}", (object?)employees[i].Title ?? DBNull.Value);
                    cmd.Parameters.AddWithValue($"@OfficePhone_{i}", (object?)employees[i].OfficePhone ?? DBNull.Value);
                    cmd.Parameters.AddWithValue($"@CellPhone_{i}", (object?)employees[i].CellPhone ?? DBNull.Value);
                    cmd.Parameters.AddWithValue($"@EmployeeClassificationKey_{i}", employees[i].EmployeeClassificationKey);
                }
                cmd.ExecuteNonQuery();
            }
        }
    }
}
