using Recipes.NPoco.Models;
using Recipes.Pagination;

namespace Recipes.NPoco.Pagination;

[TestClass]
public class PaginationTests : PaginationTests<EmployeeSimple>
{
    protected override IPaginationScenario<EmployeeSimple> GetScenario()
    {
        return new PaginationScenario(Setup.SqlServerConnectionString);
    }
}