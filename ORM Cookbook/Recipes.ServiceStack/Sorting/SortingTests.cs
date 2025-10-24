using Recipes.ServiceStack.Entities;
using Recipes.Sorting;

namespace Recipes.ServiceStack.Sorting;

[TestClass]
public class SortingTests : SortingTests<Employee>
{
    protected override ISortingScenario<Employee> GetScenario()
    {
        return new SortingScenario(Setup.DbConnectionFactory);
    }
}