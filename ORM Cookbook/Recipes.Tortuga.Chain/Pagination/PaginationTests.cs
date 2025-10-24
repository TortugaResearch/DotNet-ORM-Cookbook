using Recipes.Chain.Models;
using Recipes.Pagination;

namespace Recipes.Chain.Pagination;

[TestClass]
public class PaginationTests : PaginationTests<EmployeeSimple>
{
    protected override IPaginationScenario<EmployeeSimple> GetScenario()
    {
        return new PaginationScenario(Setup.PrimaryDataSource);
    }
}