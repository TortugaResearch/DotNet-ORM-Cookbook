using Microsoft.Data.SqlClient;
using Recipes.Ado.Models;
using Recipes.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Ado.Pagination
{
    public class PaginationScenario : SqlServerScenarioBase, IPaginationScenario<EmployeeSimple>
    {
        public PaginationScenario(string connectionString) : base(connectionString)
        { }

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

        public IList<EmployeeSimple> PaginateWithPageSize(string lastName, int page, int pageSize)
        {
            const string sql = @"SELECT e.EmployeeKey,
       e.FirstName,
       e.MiddleName,
       e.LastName,
       e.Title,
       e.OfficePhone,
       e.CellPhone,
       e.EmployeeClassificationKey
FROM HR.Employee e
WHERE e.LastName = @LastName
ORDER BY e.FirstName,
         e.EmployeeKey OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY;";

            var skip = page * pageSize;

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Skip", skip);
                cmd.Parameters.AddWithValue("@Take", pageSize);

                var results = new List<EmployeeSimple>();

                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        results.Add(new EmployeeSimple(reader));

                return results;
            }
        }

        public IList<EmployeeSimple> PaginateWithSkipPast(string lastName, EmployeeSimple? skipPast, int take)
        {
            const string sqlA = @"SELECT e.EmployeeKey,
       e.FirstName,
       e.MiddleName,
       e.LastName,
       e.Title,
       e.OfficePhone,
       e.CellPhone,
       e.EmployeeClassificationKey
FROM HR.Employee e
WHERE (e.LastName = @LastName)
ORDER BY e.FirstName,
         e.EmployeeKey
OFFSET 0 ROWS FETCH NEXT @Take ROWS ONLY;";

            const string sqlB = @"SELECT e.EmployeeKey,
       e.FirstName,
       e.MiddleName,
       e.LastName,
       e.Title,
       e.OfficePhone,
       e.CellPhone,
       e.EmployeeClassificationKey
FROM HR.Employee e
WHERE (e.LastName = @LastName)
      AND
      (
          (e.FirstName > @FirstName)
          OR
          (
              e.FirstName = @FirstName
              AND e.EmployeeKey > @EmployeeKey
          )
      )
ORDER BY e.FirstName,
         e.EmployeeKey
OFFSET 0 ROWS FETCH NEXT @Take ROWS ONLY;";

            var sql = (skipPast == null) ? sqlA : sqlB;

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Take", take);
                if (skipPast != null)
                {
                    cmd.Parameters.AddWithValue("@FirstName", skipPast.FirstName);
                    cmd.Parameters.AddWithValue("@EmployeeKey", skipPast.EmployeeKey);
                }

                var results = new List<EmployeeSimple>();

                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        results.Add(new EmployeeSimple(reader));

                return results;
            }
        }

        public IList<EmployeeSimple> PaginateWithSkipTake(string lastName, int skip, int take)
        {
            const string sql = @"SELECT e.EmployeeKey,
       e.FirstName,
       e.MiddleName,
       e.LastName,
       e.Title,
       e.OfficePhone,
       e.CellPhone,
       e.EmployeeClassificationKey
FROM HR.Employee e
WHERE e.LastName = @LastName
ORDER BY e.FirstName,
         e.EmployeeKey OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY;";

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Skip", skip);
                cmd.Parameters.AddWithValue("@Take", take);

                var results = new List<EmployeeSimple>();

                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        results.Add(new EmployeeSimple(reader));

                return results;
            }
        }
    }
}
