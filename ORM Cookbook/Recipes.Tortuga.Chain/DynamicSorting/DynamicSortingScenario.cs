using Recipes.Chain.Models;
using Recipes.DynamicSorting;
using Tortuga.Chain;

namespace Recipes.Chain.DynamicSorting;

public class DynamicSortingScenario : IDynamicSortingScenario<EmployeeSimple>
{
    readonly SqlServerDataSource m_DataSource;

    public DynamicSortingScenario(SqlServerDataSource dataSource)
    {
        m_DataSource = dataSource;
    }

    public void InsertBatch(IList<EmployeeSimple> employees)
    {
        m_DataSource.InsertBatch((IReadOnlyList<EmployeeSimple>)employees).Execute();
    }

    public IList<EmployeeSimple> SortBy(string lastName, string sortByColumn, bool isDescending)
    {
        var sortDirection = isDescending ? " DESC" : "";

        return m_DataSource.From<EmployeeSimple>(new { lastName })
            .WithSorting(sortByColumn + sortDirection)
            .ToCollection().Execute();
    }

    public IList<EmployeeSimple> SortBy(string lastName, string sortByColumnA, bool isDescendingA,
        string sortByColumnB, bool isDescendingB)
    {
        var sortDirectionA = isDescendingA ? " DESC" : "";
        var sortDirectionB = isDescendingB ? " DESC" : "";

        return m_DataSource.From<EmployeeSimple>(new { lastName })
            .WithSorting(
                sortByColumnA + sortDirectionA,
                sortByColumnB + sortDirectionB)
            .ToCollection().Execute();
    }
}