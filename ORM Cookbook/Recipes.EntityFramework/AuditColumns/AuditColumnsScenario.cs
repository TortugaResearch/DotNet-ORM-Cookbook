using Recipes.AuditColumns;
using Recipes.EntityFramework.Entities;
using System.Data.Entity;

namespace Recipes.EntityFramework.AuditColumns;

public class AuditColumnsScenario : IAuditColumnsScenario<Department>
{
    private Func<User, OrmCookbookContextWithUser> CreateDbContext;

    public AuditColumnsScenario(Func<User, OrmCookbookContextWithUser> dBContextFactory)
    {
        CreateDbContext = dBContextFactory;
    }

    public int CreateDepartment(Department department, User user)
    {
        if (department == null)
            throw new ArgumentNullException(nameof(department), $"{nameof(department)} is null.");

        using (var context = CreateDbContext(user))
        {
            context.Department.Add(department);
            context.SaveChanges();
            return department.DepartmentKey;
        }
    }

    public Department GetDepartment(int departmentKey, User user)
    {
        using (var context = CreateDbContext(user))
        {
            return context.Department.Find(departmentKey);
        }
    }

    public void UpdateDepartment(Department department, User user)
    {
        if (department == null)
            throw new ArgumentNullException(nameof(department), $"{nameof(department)} is null.");

        using (var context = CreateDbContext(user))
        {
            context.Entry(department).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}