using Recipes.EntityFrameworkCore.Entities;
using Recipes.RowCount;

namespace Recipes.EntityFrameworkCore.RowCount;

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
            return context.Employees.Where(e => e.LastName == lastName).Count();
    }

    public int EmployeeCount()
    {
        using (var context = CreateDbContext())
            return context.Employees.Count();
    }

    public void InsertBatch(IList<Employee> employees)
    {
        using (var context = CreateDbContext())
        {
            context.Employees.AddRange(employees);
            context.SaveChanges();
        }
    }
}