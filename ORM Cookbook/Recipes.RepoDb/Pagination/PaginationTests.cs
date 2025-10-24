using Recipes.Pagination;
using Recipes.RepoDB.Models;

namespace Recipes.RepoDB.Pagination;

[TestClass]
public class PaginationTests : PaginationTests<EmployeeSimple>
{
    protected override IPaginationScenario<EmployeeSimple> GetScenario()
    {
        return new PaginationScenario(Setup.ConnectionString);
    }
}