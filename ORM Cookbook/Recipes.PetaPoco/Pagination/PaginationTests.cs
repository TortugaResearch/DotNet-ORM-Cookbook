using Recipes.PetaPoco.Models;
using Recipes.Pagination;

namespace Recipes.PetaPoco.Pagination;

[TestClass]
public class PaginationTests : PaginationTests<EmployeeSimple>
{
    protected override IPaginationScenario<EmployeeSimple> GetScenario()
    {
        return new PaginationScenario(Setup.SqlServerConnectionString);
    }
}