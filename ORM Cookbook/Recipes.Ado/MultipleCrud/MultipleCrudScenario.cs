using Microsoft.Data.SqlClient;
using Recipes.Ado.Models;
using Recipes.MultipleCrud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recipes.Ado.MultipleCrud
{
    public class MultipleCrudScenario : SqlServerScenarioBase, IMultipleCrudScenario<EmployeeSimple>
    {
        public MultipleCrudScenario(string connectionString) : base(connectionString)
        { }

        public void DeleteBatch(IList<EmployeeSimple> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            var keyList = string.Join(", ", employees.Select(x => x.EmployeeKey));
            var sql = $"DELETE FROM HR.Employee WHERE EmployeeKey IN ({keyList});";

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
                cmd.ExecuteNonQuery();
        }

        public void DeleteBatchByKey(IList<int> employeeKeys)
        {
            if (employeeKeys == null || employeeKeys.Count == 0)
                throw new ArgumentException($"{nameof(employeeKeys)} is null or empty.", nameof(employeeKeys));

            var keyList = string.Join(", ", employeeKeys);
            var sql = $"DELETE FROM HR.Employee WHERE EmployeeKey IN ({keyList});";

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
                cmd.ExecuteNonQuery();
        }

        public IList<EmployeeSimple> FindByLastName(string lastName)
        {
            const string sql = "SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, e.CellPhone, e.EmployeeClassificationKey FROM HR.EmployeeDetail e WHERE e.LastName = @LastName";

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@LastName", lastName);

                var results = new List<EmployeeSimple>();

                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        results.Add(new EmployeeSimple(reader));

                return results;
            }
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

            //No transaction is needed because a single SQL statement is used.
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

        public IList<int> InsertBatchReturnKeys(IList<EmployeeSimple> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            var sql = new StringBuilder(@"INSERT INTO HR.Employee
(FirstName, MiddleName, LastName, Title, OfficePhone, CellPhone, EmployeeClassificationKey)
OUTPUT Inserted.EmployeeKey
VALUES ");

            for (var i = 0; i < employees.Count; i++)
            {
                if (i != 0)
                    sql.AppendLine(",");
                sql.Append($"(@FirstName_{i}, @MiddleName_{i}, @LastName_{i}, @Title_{i}, @OfficePhone_{i}, @CellPhone_{i}, @EmployeeClassificationKey_{i})");
            }
            sql.AppendLine(";");

            //No transaction is needed because a single SQL statement is used.
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
                var result = new List<int>();
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        result.Add(reader.GetInt32(0));
                return result;
            }
        }

        public IList<EmployeeSimple> InsertBatchReturnRows(IList<EmployeeSimple> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            var sql = new StringBuilder(@"INSERT INTO HR.Employee
(FirstName, MiddleName, LastName, Title, OfficePhone, CellPhone, EmployeeClassificationKey)
OUTPUT Inserted.EmployeeKey, Inserted.FirstName, Inserted.MiddleName, Inserted.LastName, Inserted.Title, Inserted.OfficePhone, Inserted.CellPhone, Inserted.EmployeeClassificationKey
VALUES ");

            for (var i = 0; i < employees.Count; i++)
            {
                if (i != 0)
                    sql.AppendLine(",");
                sql.Append($"(@FirstName_{i}, @MiddleName_{i}, @LastName_{i}, @Title_{i}, @OfficePhone_{i}, @CellPhone_{i}, @EmployeeClassificationKey_{i})");
            }
            sql.AppendLine(";");

            //No transaction is needed because a single SQL statement is used.
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
                var result = new List<EmployeeSimple>();
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        result.Add(new EmployeeSimple(reader));
                return result;
            }
        }

        public void InsertBatchWithRefresh(IList<EmployeeSimple> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            var sql = new StringBuilder();

            //In order to ensure the right objects are refreshed, each object is inserted separately.
            //If we returned them all at the same time, they might not come back in the same order.
            for (var i = 0; i < employees.Count; i++)
            {
                sql.AppendLine($@"INSERT INTO HR.Employee
(FirstName, MiddleName, LastName, Title, OfficePhone, CellPhone, EmployeeClassificationKey)
OUTPUT Inserted.EmployeeKey, Inserted.FirstName, Inserted.MiddleName, Inserted.LastName, Inserted.Title, Inserted.OfficePhone, Inserted.CellPhone, Inserted.EmployeeClassificationKey
VALUES (@FirstName_{i}, @MiddleName_{i}, @LastName_{i}, @Title_{i}, @OfficePhone_{i}, @CellPhone_{i}, @EmployeeClassificationKey_{i});");
            }

            //A transaction is needed because this example uses multiple SQL statements.
            using (var con = OpenConnection())
            using (var trans = con.BeginTransaction())
            {
                using (var cmd = new SqlCommand(sql.ToString(), con, trans))
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

                    using (var reader = cmd.ExecuteReader())
                    {
                        for (var i = 0; i < employees.Count; i++)
                        {
                            reader.Read();
                            employees[i].Refresh(reader);
                            reader.NextResult(); //each row is coming back as a separate result set
                        }
                    }
                }
                trans.Commit();
            }
        }

        public void UpdateBatch(IList<EmployeeSimple> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            var sql = new StringBuilder();

            for (var i = 0; i < employees.Count; i++)
            {
                sql.AppendLine($@"UPDATE HR.Employee
SET FirstName = @FirstName_{i},
    MiddleName = @MiddleName_{i},
    LastName = @LastName_{i},
    Title = @Title_{i},
    OfficePhone = @OfficePhone_{i},
    CellPhone = @CellPhone_{i},
    EmployeeClassificationKey = @EmployeeClassificationKey_{i}
WHERE EmployeeKey = @EmployeeKey_{i};");
            }

            //A transaction is needed because this example uses multiple SQL statements.
            using (var con = OpenConnection())
            using (var trans = con.BeginTransaction())
            {
                using (var cmd = new SqlCommand(sql.ToString(), con, trans))
                {
                    for (var i = 0; i < employees.Count; i++)
                    {
                        cmd.Parameters.AddWithValue($"@EmployeeKey_{i}", employees[i].EmployeeKey);
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
                trans.Commit();
            }
        }
    }
}
