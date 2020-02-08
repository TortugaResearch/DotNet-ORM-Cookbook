using Dapper;
using Recipes.AuditColumns;
using Recipes.Dapper.Models;
using System;

namespace Recipes.Dapper.AuditColumns
{
    public class AuditColumnsScenario : ScenarioBase, IAuditColumnsScenario<Department>
    {
        public AuditColumnsScenario(string connectionString) : base(connectionString)
        { }

        public int CreateDepartment(Department department, User user)
        {
            if (department == null)
                throw new ArgumentNullException(nameof(department), $"{nameof(department)} is null.");
            if (user == null)
                throw new ArgumentNullException(nameof(user), $"{nameof(user)} is null.");

            //Manually apply the audit columns
            department.CreatedDate = DateTime.UtcNow;
            department.ModifiedDate = DateTime.UtcNow;
            department.CreatedByEmployeeKey = user.UserKey;
            department.ModifiedByEmployeeKey = user.UserKey;

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
                return con.ExecuteScalar<int>(sql, department);
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
                return con.QuerySingle<Department>(sql, new { departmentKey });
        }

        public void UpdateDepartment(Department department, User user)
        {
            if (department == null)
                throw new ArgumentNullException(nameof(department), $"{nameof(department)} is null.");
            if (user == null)
                throw new ArgumentNullException(nameof(user), $"{nameof(user)} is null.");

            //Manually apply the audit columns
            department.ModifiedDate = DateTime.UtcNow;
            department.ModifiedByEmployeeKey = user.UserKey;

            const string sql = @"UPDATE HR.Department SET
    DepartmentName = @DepartmentName,
    DivisionKey = @DivisionKey,
    ModifiedDate = @ModifiedDate,
    ModifiedByEmployeeKey = @ModifiedByEmployeeKey
WHERE DepartmentKey = @DepartmentKey;";

            using (var con = OpenConnection())
                con.Execute(sql, department);
        }
    }
}
