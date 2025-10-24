using Recipes.EntityFramework.Entities;
using Recipes.RowCount;

namespace Recipes.EntityFramework.RowCount;

public class RowCountScenario : IRowCountScenario<Employee>
{
    private Func<OrmCookbookContext> CreateDbContext;

    public RowCountScenario(Func<OrmCookbookContext> dBContextFactory)
    {
        CreateDbContext = dBContextFactory;
    }

    public int EmployeeCount(string lastName)
    {
        using (var context = CreateDbContext())
            return context.Employee.Where(e => e.LastName == lastName).Count();
    }

    public int EmployeeCount()
    {
        using (var context = CreateDbContext())
            return context.Employee.Count();
    }

    public void InsertBatch(IList<Employee> employees)
    {
        using (var context = CreateDbContext())
        {
            context.Employee.AddRange(employees);
            context.SaveChanges();
        }
    }
}