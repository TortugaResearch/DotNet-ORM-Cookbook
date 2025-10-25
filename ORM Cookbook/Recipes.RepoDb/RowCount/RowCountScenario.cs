using Recipes.RepoDB.Models;
using Recipes.RowCount;

using RDB = RepoDb;

namespace Recipes.RepoDB.RowCount;

public class RowCountScenario(string connectionString) : IRowCountScenario<EmployeeSimple>
{
    public int EmployeeCount(string lastName)
    {
        using var repository = new EmployeeSimpleRepository(connectionString, RDB.Enumerations.ConnectionPersistency.Instance);

        return (int)repository.Count(e => e.LastName == lastName);
    }

    public int EmployeeCount()
    {
        using var repository = new EmployeeSimpleRepository(connectionString, RDB.Enumerations.ConnectionPersistency.Instance);

        return (int)repository.CountAll();
    }

    public void InsertBatch(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        using var repository = new EmployeeSimpleRepository(connectionString, RDB.Enumerations.ConnectionPersistency.Instance);

        repository.InsertAll(employees);
    }
}