using Recipes.Chain.Models;
using Recipes.SoftDelete;
using Tortuga.Chain;
using Tortuga.Chain.AuditRules;

namespace Recipes.Chain.SoftDelete;

public class SoftDeleteScenario : ISoftDeleteScenario<Department>
{
    private const string TableName = "HR.Department";
    readonly SqlServerDataSource m_DataSource;
    readonly SqlServerDataSource m_DataSourceBypassSoftDelete;

    public SoftDeleteScenario(SqlServerDataSource dataSource)
    {
        if (dataSource == null)
            throw new ArgumentNullException(nameof(dataSource), $"{nameof(dataSource)} is null.");

        //We need the original data source without the soft delete rule enabled for the by-pass scenario.
        m_DataSourceBypassSoftDelete = dataSource;

        //Normally this would be configured application-wide, not just for one repository instance.
        m_DataSource = dataSource.WithRules(
        new SoftDeleteRule("IsDeleted", true, OperationTypes.SelectOrDelete)
        );
    }

    public int CreateDepartment(Department department, User user)
    {
        return m_DataSource.WithUser(user).Insert(department).ToInt32().Execute();
    }

    public int CreateDepartment(Department department)
    {
        return m_DataSource.Insert(department).ToInt32().Execute();
    }

    public void DeleteDepartment(Department department)
    {
        m_DataSource.Delete(department).Execute();
    }

    public Department? GetDepartment(int departmentKey)
    {
        return m_DataSource.GetByKey<Department>(departmentKey).ToObjectOrNull().Execute();
    }

    public Department? GetDepartmentIgnoringIsDeleted(int departmentKey)
    {
        return m_DataSourceBypassSoftDelete.GetByKey<Department>(departmentKey).ToObjectOrNull().Execute();
    }

    public void UndeleteDepartment(int departmentKey)
    {
        //The SoftDeleteRule does not apply to Update operations
        m_DataSource.Update(TableName, new { departmentKey, IsDeleted = false }).Execute();
    }

    public void UpdateDepartment(Department department)
    {
        m_DataSource.Update(department).Execute();
    }
}