using Recipes.EntityFrameworkCore.Entities;
using Recipes.QueryFilter;

namespace Recipes.EntityFrameworkCore.QueryFilter;

[TestClass]
public class QueryFilterTests : QueryFilterTests<Student>
{
    protected override IQueryFilterScenario<Student> GetScenario()
    {
        return new QueryFilterScenario(Setup.DBContextWithFilter);
    }
}