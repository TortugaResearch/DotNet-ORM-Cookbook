using Recipes.EntityFramework.Entities;
using Recipes.MultipleCrud;

namespace Recipes.EntityFramework.MultipleCrud;

[TestClass]
public class MultipleCrudTests : MultipleCrudTests<Employee>
{
    protected override IMultipleCrudScenario<Employee> GetScenario()
    {
        return new MultipleCrudScenario(Setup.DBContextFactory);
    }
}