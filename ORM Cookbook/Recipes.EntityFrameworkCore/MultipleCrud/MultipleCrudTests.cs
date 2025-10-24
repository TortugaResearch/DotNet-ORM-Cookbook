using Recipes.EntityFrameworkCore.Entities;
using Recipes.MultipleCrud;

namespace Recipes.EntityFrameworkCore.MultipleCrud;

[TestClass]
public class MultipleCrudTests : MultipleCrudTests<Employee>
{
    protected override IMultipleCrudScenario<Employee> GetScenario()
    {
        return new MultipleCrudScenario(Setup.DBContextFactory);
    }
}