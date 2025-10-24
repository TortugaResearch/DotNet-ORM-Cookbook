using Recipes.DynamicSorting;
using Recipes.ServiceStack.Entities;

namespace Recipes.ServiceStack.DynamicSorting;

[TestClass]
public class DynamicSortingTests : DynamicSortingTests<Employee>
{
    protected override IDynamicSortingScenario<Employee> GetScenario()
    {
        return new DynamicSortingScenario(Setup.DbConnectionFactory);
    }
}