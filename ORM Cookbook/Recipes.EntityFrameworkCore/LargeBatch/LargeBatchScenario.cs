using Recipes.EntityFrameworkCore.Entities;
using Recipes.LargeBatch;

namespace Recipes.EntityFrameworkCore.LargeBatch;

public class LargeBatchScenario : ILargeBatchScenario<Employee>
{
    private Func<OrmCookbookContext> CreateDbContext;

    public LargeBatchScenario(Func<OrmCookbookContext> dBContextFactory)
    {
        CreateDbContext = dBContextFactory;
    }

    public int MaximumBatchSize => int.MaxValue;

    public int CountByLastName(string lastName)
    {
        using (var context = CreateDbContext())
            return context.Employees.Where(ec => ec.LastName == lastName).Count();
    }

    public void InsertLargeBatch(IList<Employee> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        using (var context = CreateDbContext())
        {
            context.Employees.AddRange(employees);
            context.SaveChanges();
        }
    }

    public void InsertLargeBatch(IList<Employee> employees, int batchSize)
    {
        foreach (var batch in employees.BatchAsLists(batchSize))
        {
            using (var context = CreateDbContext())
            {
                context.Employees.AddRange(batch);
                context.SaveChanges();
            }
        }
    }
}