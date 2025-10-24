using Recipes.MultipleCrud;
using Recipes.ServiceStack.Entities;

namespace Recipes.ServiceStack.MultipleCrud;

[TestClass]
public class MultipleCrudTests : MultipleCrudTests<Employee>
{
    protected override IMultipleCrudScenario<Employee> GetScenario()
    {
        return new MultipleCrudScenario(Setup.DbConnectionFactory);
    }
}