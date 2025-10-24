using Recipes.DbConnector.Models;
using Recipes.SoftDelete;

namespace Recipes.DbConnector.SoftDelete;

public class SoftDeleteScenario : ScenarioBase, ISoftDeleteScenario<Department>
{
    public SoftDeleteScenario(string connectionString) : base(connectionString)
    {
    }

    public int CreateDepartment(Department department)
    {
        if (department == null)
            throw new ArgumentNullException(nameof(department), $"{nameof(department)} is null.");

        string sql = $@"INSERT INTO {Department.TableName}
                        (
                            DepartmentName,
                            DivisionKey,
                            CreatedDate,
                            ModifiedDate,
                            CreatedByEmployeeKey,
                            ModifiedByEmployeeKey,
                            IsDeleted
                        )
                        OUTPUT Inserted.DepartmentKey
                        VALUES
                        (
                            @{nameof(Department.DepartmentName)},
                            @{nameof(Department.DivisionKey)},
                            @{nameof(Department.CreatedDate)},
                            @{nameof(Department.ModifiedDate)},
                            @{nameof(Department.CreatedByEmployeeKey)},
                            @{nameof(Department.ModifiedByEmployeeKey)},
                            @{nameof(Department.IsDeleted)}
                        )";

        return DbConnector.Scalar<int>(sql, department).Execute();
    }

    public void DeleteDepartment(Department department)
    {
        if (department == null)
            throw new ArgumentNullException(nameof(department), $"{nameof(department)} is null.");

        string sql = $@"
                            UPDATE {Department.TableName}
                            SET
                                IsDeleted = @isDeleted
                            WHERE DepartmentKey = @DepartmentKey;";

        DbConnector.NonQuery(sql, new { department.DepartmentKey, isDeleted = true }).Execute();
    }

    public Department? GetDepartment(int departmentKey)
    {
        string sql = $"Select * FROM {Department.TableName} WHERE DepartmentKey = @departmentKey AND IsDeleted = 0;";

        return DbConnector.ReadFirstOrDefault<Department>(sql, new { departmentKey }).Execute();
    }

    public Department? GetDepartmentIgnoringIsDeleted(int departmentKey)
    {
        string sql = $"Select * FROM {Department.TableName} WHERE DepartmentKey = @departmentKey;";

        return DbConnector.ReadFirstOrDefault<Department>(sql, new { departmentKey }).Execute();
    }

    public void UndeleteDepartment(int departmentKey)
    {
        string sql = $@"
                            UPDATE {Department.TableName}
                            SET
                                IsDeleted = @isDeleted
                            WHERE DepartmentKey = @departmentKey;";

        DbConnector.NonQuery(sql, new { departmentKey, isDeleted = false }).Execute();
    }

    public void UpdateDepartment(Department department)
    {
        string sql = $@"
                            UPDATE {Department.TableName}
                            SET
                                DepartmentName = @{nameof(Department.DepartmentName)},
                                DivisionKey = @{nameof(Department.DivisionKey)},
                                CreatedDate = @{nameof(Department.CreatedDate)},
                                ModifiedDate = @{nameof(Department.ModifiedDate)},
                                CreatedByEmployeeKey = @{nameof(Department.CreatedByEmployeeKey)},
                                ModifiedByEmployeeKey = @{nameof(Department.ModifiedByEmployeeKey)},
                                IsDeleted = @{nameof(Department.IsDeleted)}
                            WHERE DepartmentKey = @{nameof(Department.DepartmentKey)};";

        DbConnector.NonQuery(sql, department).Execute();
    }
}