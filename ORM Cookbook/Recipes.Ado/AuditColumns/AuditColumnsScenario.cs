using Microsoft.Data.SqlClient;
using Recipes.Ado.Models;
using Recipes.AuditColumns;

namespace Recipes.Ado.AuditColumns;

public class AuditColumnsScenario : SqlServerScenarioBase, IAuditColumnsScenario<Department>
{
    public AuditColumnsScenario(string connectionString) : base(connectionString)
    { }

    public int CreateDepartment(Department department, User user)
    {
        if (department == null)
            throw new ArgumentNullException(nameof(department), $"{nameof(department)} is null.");
        if (user == null)
            throw new ArgumentNullException(nameof(user), $"{nameof(user)} is null.");

        const string sql = @"INSERT INTO HR.Department
(
    DepartmentName,
    DivisionKey,
    CreatedDate,
    ModifiedDate,
    CreatedByEmployeeKey,
    ModifiedByEmployeeKey
)
OUTPUT Inserted.DepartmentKey
VALUES
(@DepartmentName, @DivisionKey, @CreatedDate, @ModifiedDate, @CreatedByEmployeeKey, @ModifiedByEmployeeKey);";

        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
            cmd.Parameters.AddWithValue("@DivisionKey", department.DivisionKey);
            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.UtcNow);
            cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.UtcNow);
            cmd.Parameters.AddWithValue("@CreatedByEmployeeKey", user.UserKey);
            cmd.Parameters.AddWithValue("@ModifiedByEmployeeKey", user.UserKey);
            return (int)cmd.ExecuteScalar();
        }
    }

    public Department GetDepartment(int departmentKey, User user)
    {
        const string sql = @"SELECT d.DepartmentKey,
       d.DepartmentName,
       d.DivisionKey,
       d.CreatedDate,
       d.ModifiedDate,
       d.CreatedByEmployeeKey,
       d.ModifiedByEmployeeKey FROM HR.Department d WHERE d.DepartmentKey = @DepartmentKey";

        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@DepartmentKey", departmentKey);
            using (var reader = cmd.ExecuteReader())
            {
                reader.Read();

                return new Department(reader);
            }
        }
    }

    public void UpdateDepartment(Department department, User user)
    {
        if (department == null)
            throw new ArgumentNullException(nameof(department), $"{nameof(department)} is null.");
        if (user == null)
            throw new ArgumentNullException(nameof(user), $"{nameof(user)} is null.");

        const string sql = @"UPDATE HR.Department SET
    DepartmentName = @DepartmentName,
    DivisionKey = @DivisionKey,
    ModifiedDate = @ModifiedDate,
    ModifiedByEmployeeKey = @ModifiedByEmployeeKey
WHERE DepartmentKey = @DepartmentKey;";

        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@DepartmentKey", department.DepartmentKey);
            cmd.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
            cmd.Parameters.AddWithValue("@DivisionKey", department.DivisionKey);
            cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.UtcNow);
            cmd.Parameters.AddWithValue("@ModifiedByEmployeeKey", user.UserKey);
            cmd.ExecuteNonQuery();
        }
    }
}