using Recipes.AuditColumns;
using Recipes.NPoco.Models;

namespace Recipes.NPoco.AuditColumns;

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

        throw new NotImplementedException();
    }

    public Department GetDepartment(int departmentKey, User user)
    {
        throw new NotImplementedException();
    }

    public void UpdateDepartment(Department department, User user)
    {
        if (department == null)
            throw new ArgumentNullException(nameof(department), $"{nameof(department)} is null.");
        if (user == null)
            throw new ArgumentNullException(nameof(user), $"{nameof(user)} is null.");

        throw new NotImplementedException();
    }
}