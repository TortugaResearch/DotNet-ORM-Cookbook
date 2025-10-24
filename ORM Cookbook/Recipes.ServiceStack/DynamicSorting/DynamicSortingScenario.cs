using Recipes.DynamicSorting;
using Recipes.ServiceStack.Entities;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Recipes.ServiceStack.DynamicSorting;

public class DynamicSortingScenario : IDynamicSortingScenario<Employee>
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public DynamicSortingScenario(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public void InsertBatch(IList<Employee> employees)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
            db.InsertAll(employees);
    }

    public IList<Employee> SortBy(string lastName, string sortByColumn, bool isDescending)
    {
        if (!Utilities.EmployeeColumnNames.Contains(sortByColumn))
            throw new ArgumentOutOfRangeException(nameof(sortByColumn), "Unknown column " + sortByColumn);

        var sortDirection = isDescending ? " DESC " : "";

        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            return db.Select(db.From<Employee>().Where(x => x.LastName == lastName)
                .OrderBy(sortByColumn + sortDirection)).ToList();
        }
    }

    public IList<Employee> SortBy(string lastName, string sortByColumnA, bool isDescendingA,
        string sortByColumnB, bool isDescendingB)
    {
        if (!Utilities.EmployeeColumnNames.Contains(sortByColumnA))
            throw new ArgumentOutOfRangeException(nameof(sortByColumnA), "Unknown column " + sortByColumnA);
        if (!Utilities.EmployeeColumnNames.Contains(sortByColumnB))
            throw new ArgumentOutOfRangeException(nameof(sortByColumnB), "Unknown column " + sortByColumnB);

        var sortDirectionA = isDescendingA ? " DESC " : "";
        var sortDirectionB = isDescendingB ? " DESC " : "";

        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            return db.Select(db.From<Employee>().Where(x => x.LastName == lastName)
                .OrderBy(sortByColumnA + sortDirectionA + "," + sortByColumnB + sortDirectionB)).ToList();
        }
    }
}