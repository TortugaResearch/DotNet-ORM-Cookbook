using Recipes.Chain.Models;
using Recipes.Pagination;
using Tortuga.Chain;

namespace Recipes.Chain.Pagination;

public class PaginationScenario : IPaginationScenario<EmployeeSimple>
{
    readonly SqlServerDataSource m_DataSource;

    public PaginationScenario(SqlServerDataSource dataSource)
    {
        m_DataSource = dataSource;
    }

    public void InsertBatch(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        m_DataSource.InsertBatch((IReadOnlyList<EmployeeSimple>)employees).Execute();
    }

    public IList<EmployeeSimple> PaginateWithPageSize(string lastName, int page, int pageSize)
    {
        return m_DataSource.From<EmployeeSimple>(new { lastName })
            .WithSorting("FirstName", "EmployeeKey")
            .WithLimits(page * pageSize, pageSize)
            .ToCollection().Execute();
    }

    public IList<EmployeeSimple> PaginateWithSkipPast(string lastName, EmployeeSimple? skipPast, int take)
    {
        var link = (skipPast == null) ?
            m_DataSource.From<EmployeeSimple>(new { lastName }) :
            m_DataSource.From<EmployeeSimple>("LastName = @LastName AND ((FirstName > @FirstName) OR (FirstName = @FirstName AND EmployeeKey > @EmployeeKey))",
            new { lastName, skipPast.FirstName, skipPast.EmployeeKey });

        return link
            .WithSorting("FirstName", "EmployeeKey")
            .WithLimits(take)
            .ToCollection().Execute();
    }

    public IList<EmployeeSimple> PaginateWithSkipTake(string lastName, int skip, int take)
    {
        return m_DataSource.From<EmployeeSimple>(new { lastName })
            .WithSorting("FirstName", "EmployeeKey")
            .WithLimits(skip, take)
            .ToCollection().Execute();
    }
}