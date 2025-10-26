using Recipes.NPoco.Models;
using Recipes.Pagination;

namespace Recipes.NPoco.Pagination;

public class PaginationScenario : ScenarioBase, IPaginationScenario<EmployeeSimple>
{
    public PaginationScenario(string connectionString) : base(connectionString)
    { }

    public void InsertBatch(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        throw new NotImplementedException();
    }

    public IList<EmployeeSimple> PaginateWithPageSize(string lastName, int page, int pageSize)
    {
        throw new NotImplementedException();
    }

    public IList<EmployeeSimple> PaginateWithSkipPast(string lastName, EmployeeSimple? skipPast, int take)
    {
        throw new NotImplementedException();
    }

    public IList<EmployeeSimple> PaginateWithSkipTake(string lastName, int skip, int take)
    {
        throw new NotImplementedException();
    }
}