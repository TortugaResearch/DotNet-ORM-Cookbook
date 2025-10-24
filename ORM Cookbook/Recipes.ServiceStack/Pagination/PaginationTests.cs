using Recipes.Pagination;
using Recipes.ServiceStack.Entities;

namespace Recipes.ServiceStack.Pagination;

[TestClass]
public class PaginationTests : PaginationTests<Employee>
{
    protected override IPaginationScenario<Employee> GetScenario()
    {
        return new PaginationScenario(Setup.DbConnectionFactory);
    }
}