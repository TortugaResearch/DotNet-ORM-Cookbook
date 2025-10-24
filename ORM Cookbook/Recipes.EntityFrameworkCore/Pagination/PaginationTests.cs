using Recipes.EntityFrameworkCore.Entities;
using Recipes.Pagination;

namespace Recipes.EntityFrameworkCore.Pagination;

[TestClass]
public class PaginationTests : PaginationTests<Employee>
{
    protected override IPaginationScenario<Employee> GetScenario()
    {
        return new PaginationScenario(Setup.DBContextFactory);
    }
}