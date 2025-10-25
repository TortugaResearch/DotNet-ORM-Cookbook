using Microsoft.Data.SqlClient;
using Recipes.RepoDB.Models;
using Recipes.Sorting;
using RepoDb;
using RepoDb.Enumerations;
using RepoDb.Extensions;

using RDB = RepoDb;

namespace Recipes.RepoDB.Sorting;

public class SortingScenario(string connectionString) :
    ISortingScenario<EmployeeSimple>
{
    public void InsertBatch(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        using var repository = new EmployeeSimpleRepository(connectionString, ConnectionPersistency.Instance);

        repository.InsertAll(employees);
    }

    public IList<EmployeeSimple> SortByFirstName(string lastName)
    {
        using var repository = new EmployeeSimpleRepository(connectionString, ConnectionPersistency.Instance);

        return repository.Query(x => x.LastName == lastName)
            .OrderBy(x => x.FirstName).AsList();
    }

    public IList<EmployeeSimple> SortByMiddleNameDescFirstName(string lastName)
    {
        using var repository = new EmployeeSimpleRepository(connectionString, ConnectionPersistency.Instance);

        return repository.Query(x => x.LastName == lastName)
            .OrderByDescending(x => x.MiddleName).ThenBy(x => x.FirstName).AsList();
    }

    public IList<EmployeeSimple> SortByMiddleNameFirstName(string lastName)
    {
        using var repository = new EmployeeSimpleRepository(connectionString, ConnectionPersistency.Instance);

        return repository.Query(x => x.LastName == lastName)
            .OrderBy(x => x.MiddleName).ThenBy(x => x.FirstName).AsList();
    }
}