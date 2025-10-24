using Recipes.AuditColumns;
using Recipes.Chain.Models;
using Tortuga.Chain;
using Tortuga.Chain.AuditRules;

namespace Recipes.Chain.AuditColumns;

public class AuditColumnsScenario :
    IAuditColumnsScenario<Department>
{
    readonly SqlServerDataSource m_DataSource;

    public AuditColumnsScenario(SqlServerDataSource dataSource)
    {
        if (dataSource == null)
            throw new ArgumentNullException(nameof(dataSource), $"{nameof(dataSource)} is null.");

        //Normally this would be configured application-wide, not just for one repository instance.
        m_DataSource = dataSource.WithRules(
            new DateTimeRule("CreatedDate", DateTimeKind.Utc, OperationTypes.Insert),
            new DateTimeRule("ModifiedDate", DateTimeKind.Utc, OperationTypes.InsertOrUpdate),
            new UserDataRule("CreatedByEmployeeKey", "UserKey", OperationTypes.Insert),
            new UserDataRule("ModifiedByEmployeeKey", "UserKey", OperationTypes.InsertOrUpdate)
            );
    }

    public int CreateDepartment(Department department, User user)
    {
        return m_DataSource.WithUser(user).Insert(department).ToInt32().Execute();
    }

    public Department GetDepartment(int departmentKey, User user)
    {
        return m_DataSource.WithUser(user).GetByKey<Department>(departmentKey).ToObject().Execute();
    }

    public void UpdateDepartment(Department department, User user)
    {
        m_DataSource.WithUser(user).Update(department).Execute();
    }
}