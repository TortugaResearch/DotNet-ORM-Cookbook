using Recipes.Ado.Models;
using Recipes.Pagination;

namespace Recipes.Ado.Pagination;

[TestClass]
public class PaginationTests : PaginationTests<EmployeeSimple>
{
    protected override IPaginationScenario<EmployeeSimple> GetScenario()
    {
        return new PaginationScenario(Setup.SqlServerConnectionString);
    }
}