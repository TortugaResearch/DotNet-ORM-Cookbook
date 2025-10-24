using Recipes.EntityFramework.Entities;
using Recipes.LargeBatch;

namespace Recipes.EntityFramework.LargeBatch;

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
            return context.Employee.Where(ec => ec.LastName == lastName).Count();
    }

    public void InsertLargeBatch(IList<Employee> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        //Performance can be significantly degraded as the size of the batch increases
        InsertLargeBatch(employees, 50);
    }

    public void InsertLargeBatch(IList<Employee> employees, int batchSize)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        foreach (var batch in employees.BatchAsLists(batchSize))
        {
            using (var context = CreateDbContext())
            {
                context.Employee.AddRange(batch);
                context.SaveChanges();
            }
        }
    }
}