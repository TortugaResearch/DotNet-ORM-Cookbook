using Recipes.Dapper.Models;
using Recipes.Pagination;

namespace Recipes.Dapper.Pagination;

[TestClass]
public class PaginationTests : PaginationTests<EmployeeSimple>
{
    protected override IPaginationScenario<EmployeeSimple> GetScenario()
    {
        return new PaginationScenario(Setup.SqlServerConnectionString);
    }
}