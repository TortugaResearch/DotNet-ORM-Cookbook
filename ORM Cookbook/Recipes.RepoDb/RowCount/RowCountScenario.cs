using Recipes.RepoDB.Models;
using Recipes.RowCount;
using RepoDb.Enumerations;

namespace Recipes.RepoDB.RowCount;

public class RowCountScenario : IRowCountScenario<EmployeeSimple>
{
    readonly string m_ConnectionString;

    public RowCountScenario(string connectionString)
    {
        m_ConnectionString = connectionString;
    }

    public int EmployeeCount(string lastName)
    {
        using (var repository = new EmployeeSimpleRepository(m_ConnectionString, ConnectionPersistency.Instance))
        return (int)repository.Count(e => e.LastName == lastName);
    }

    public int EmployeeCount()
    {
        using (var repository = new EmployeeSimpleRepository(m_ConnectionString, ConnectionPersistency.Instance))
        return (int)repository.CountAll();
    }

    public void InsertBatch(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        using (var repository = new EmployeeSimpleRepository(m_ConnectionString, ConnectionPersistency.Instance))
        repository.InsertAll(employees);
    }
}