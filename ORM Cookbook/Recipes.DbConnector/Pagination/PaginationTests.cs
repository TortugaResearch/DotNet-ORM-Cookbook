using Recipes.DbConnector.Models;
using Recipes.Pagination;

namespace Recipes.DbConnector.Pagination;

[TestClass]
public class PaginationTests : PaginationTests<EmployeeSimple>
{
    protected override IPaginationScenario<EmployeeSimple> GetScenario()
    {
        return new PaginationScenario(Setup.SqlServerConnectionString);
    }
}