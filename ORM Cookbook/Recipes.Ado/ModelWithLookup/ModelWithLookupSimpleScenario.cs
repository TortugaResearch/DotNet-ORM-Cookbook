using Microsoft.Data.SqlClient;
using Recipes.Ado.Models;
using Recipes.ModelWithLookup;
using System;
using System.Collections.Generic;

namespace Recipes.Ado.ModelWithLookup
{
    public class ModelWithLookupSimpleScenario : SqlServerScenarioBase, IModelWithLookupSimpleScenario<EmployeeSimple>
    {
        public ModelWithLookupSimpleScenario(string connectionString) : base(connectionString)
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

        public void Delete(EmployeeSimple employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

            const string sql = @"DELETE HR.Employee WHERE EmployeeKey = @EmployeeKey;";

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@EmployeeKey", employee.EmployeeKey);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteByKey(int employeeKey)
        {
            const string sql = @"DELETE HR.Employee WHERE EmployeeKey = @EmployeeKey;";

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@EmployeeKey", employeeKey);
                cmd.ExecuteNonQuery();
            }
        }

        public IList<EmployeeSimple> FindByLastName(string lastName)
        {
            const string sql = @"SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, e.CellPhone,        e.EmployeeClassificationKey FROM HR.Employee e WHERE e.LastName = @LastName";

            var result = new List<EmployeeSimple>();

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@LastName", lastName);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new EmployeeSimple(reader));
                    }
                    return result;
                }
            }
        }

        public IList<EmployeeSimple> GetAll()
        {
            const string sql = @"SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, e.CellPhone,        e.EmployeeClassificationKey FROM HR.Employee e";

            var result = new List<EmployeeSimple>();

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new EmployeeSimple(reader));
                }
                return result;
            }
        }

        public EmployeeSimple? GetByKey(int employeeKey)
        {
            const string sql = @"SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, e.CellPhone,        e.EmployeeClassificationKey FROM HR.Employee e WHERE e.EmployeeKey = @EmployeeKey";

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@EmployeeKey", employeeKey);
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        return null;

                    return new EmployeeSimple(reader);
                }
            }
        }

        public IEmployeeClassification? GetClassification(int employeeClassificationKey)
        {
            const string sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@EmployeeClassificationKey", employeeClassificationKey);
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        return null;

                    return new EmployeeClassification()
                    {
                        EmployeeClassificationKey = reader.GetInt32(reader.GetOrdinal("EmployeeClassificationKey")),
                        EmployeeClassificationName = reader.GetString(reader.GetOrdinal("EmployeeClassificationName")),
                        IsExempt = reader.GetBoolean(reader.GetOrdinal("IsExempt")),
                        IsEmployee = reader.GetBoolean(reader.GetOrdinal("IsEmployee"))
                    };
                }
            }
        }

        public void Update(EmployeeSimple employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

            const string sql = @"UPDATE HR.Employee
SET FirstName = @FirstName,
    MiddleName = @MiddleName,
    LastName = @LastName,
    Title = @Title,
    OfficePhone = @OfficePhone,
    CellPhone = @CellPhone,
    EmployeeClassificationKey = @EmployeeClassificationKey
WHERE EmployeeKey = @EmployeeKey;";

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@EmployeeKey", employee.EmployeeKey);

                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", (object?)employee.MiddleName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                cmd.Parameters.AddWithValue("@Title", (object?)employee.Title ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@OfficePhone", (object?)employee.OfficePhone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CellPhone", (object?)employee.CellPhone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@EmployeeClassificationKey", employee.EmployeeClassificationKey);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
