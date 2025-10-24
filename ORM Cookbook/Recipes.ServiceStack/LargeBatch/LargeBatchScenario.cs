using Recipes.LargeBatch;
using Recipes.ServiceStack.Entities;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Recipes.ServiceStack.LargeBatch;

public class LargeBatchScenario : ILargeBatchScenario<Employee>
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public LargeBatchScenario(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public int MaximumBatchSize => int.MaxValue;

    public int CountByLastName(string lastName)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
            return (int)db.Count<Employee>(e => e.LastName == lastName);
    }

    public void InsertLargeBatch(IList<Employee> employees)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
            db.InsertAll(employees);
    }

    public void InsertLargeBatch(IList<Employee> employees, int batchSize)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            foreach (var batch in employees.BatchAsLists(batchSize))
                db.InsertAll(batch);
        }
    }
}