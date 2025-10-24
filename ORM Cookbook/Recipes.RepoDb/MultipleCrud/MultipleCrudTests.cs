using Recipes.MultipleCrud;
using Recipes.RepoDB.Models;

namespace Recipes.RepoDB.MultipleCrud;

[TestClass]
public class MultipleCrudTests : MultipleCrudTests<EmployeeSimple>
{
    protected override IMultipleCrudScenario<EmployeeSimple> GetScenario()
    {
        return new MultipleCrudScenario(Setup.ConnectionString);
    }
}