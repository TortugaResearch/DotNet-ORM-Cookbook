using Recipes.DynamicSorting;
using Recipes.RepoDB.Models;
using RepoDb;
using RepoDb.Enumerations;
using RepoDb.Extensions;

namespace Recipes.RepoDB.DynamicSorting;

public class DynamicSortingScenario(string connectionString) : IDynamicSortingScenario<EmployeeSimple>
{
    public void InsertBatch(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        using var repository = new EmployeeSimpleRepository(connectionString, ConnectionPersistency.Instance);

        repository.InsertAll(employees);
    }

    public IList<EmployeeSimple> SortBy(string lastName, string sortByColumn, bool isDescending)
    {
        using var repository = new EmployeeSimpleRepository(connectionString, ConnectionPersistency.Instance);

        var sort = new[] { new OrderField(sortByColumn, isDescending ? Order.Descending : Order.Ascending) };
        return repository.Query(x => x.LastName == lastName, orderBy: sort).AsList();
    }

    public IList<EmployeeSimple> SortBy(string lastName, string sortByColumnA, bool isDescendingA, string sortByColumnB, bool isDescendingB)
    {
        using var repository = new EmployeeSimpleRepository(connectionString, ConnectionPersistency.Instance);

        var sort = new[] {
            new OrderField(sortByColumnA, isDescendingA ? Order.Descending : Order.Ascending),
            new OrderField(sortByColumnB, isDescendingB ? Order.Descending : Order.Ascending)
        };
        return repository.Query(x => x.LastName == lastName, orderBy: sort).AsList();
    }
}