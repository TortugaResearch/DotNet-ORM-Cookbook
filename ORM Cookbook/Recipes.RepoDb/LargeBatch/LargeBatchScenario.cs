using Recipes.LargeBatch;
using Recipes.RepoDB.Models;
using RepoDb;
using RepoDb.Enumerations;

namespace Recipes.RepoDB.LargeBatch;

public class LargeBatchScenario : ILargeBatchScenario<EmployeeSimple>
{
    readonly string m_ConnectionString;

    public LargeBatchScenario(string connectionString)
    {
        m_ConnectionString = connectionString;
    }

    public int CountByLastName(string lastName)
    {
        using (var repository = new EmployeeSimpleRepository(m_ConnectionString, ConnectionPersistency.Instance))
        return repository.Query(e => e.LastName == lastName).Count();
    }

    public int MaximumBatchSize => 2100 / 7;

    public void InsertLargeBatch(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        using (var repository = new EmployeeSimpleRepository(m_ConnectionString, ConnectionPersistency.Instance))
        repository.InsertAll(employees);
    }

    public void InsertLargeBatch(IList<EmployeeSimple> employees, int batchSize)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        using (var repository = new EmployeeSimpleRepository(m_ConnectionString, ConnectionPersistency.Instance))
        repository.InsertAll(employees, batchSize: batchSize);
    }
}