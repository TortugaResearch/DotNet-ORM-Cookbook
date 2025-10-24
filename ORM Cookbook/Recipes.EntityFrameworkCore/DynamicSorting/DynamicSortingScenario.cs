using Recipes.DynamicSorting;
using Recipes.EntityFrameworkCore.Entities;

namespace Recipes.EntityFrameworkCore.DynamicSorting;

public class DynamicSortingScenario : IDynamicSortingScenario<Employee>
{
    private Func<OrmCookbookContext> CreateDbContext;

    public DynamicSortingScenario(Func<OrmCookbookContext> dBContextFactory)
    {
        CreateDbContext = dBContextFactory;
    }

    public void InsertBatch(IList<Employee> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        using (var context = CreateDbContext())
        {
            foreach (var employee in employees)
                context.Employees.Add(employee);
            context.SaveChanges();
        }
    }

    public IList<Employee> SortBy(string lastName, string sortByColumn, bool isDescending)
    {
        using (var context = CreateDbContext())
            return context.Employees.Where(x => x.LastName == lastName)
                .OrderBy(sortByColumn, isDescending).ToList();
    }

    public IList<Employee> SortBy(string lastName, string sortByColumnA, bool isDescendingA,
        string sortByColumnB, bool isDescendingB)
    {
        using (var context = CreateDbContext())
            return context.Employees.Where(x => x.LastName == lastName)
                .OrderBy(sortByColumnA, isDescendingA)
                .ThenBy(sortByColumnB, isDescendingB)
                .ToList();
    }
}