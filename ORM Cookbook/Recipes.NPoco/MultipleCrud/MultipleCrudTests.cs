using Recipes.NPoco.Models;
using Recipes.MultipleCrud;

namespace Recipes.NPoco.MultipleCrud;

[TestClass]
public class MultipleCrudTests : MultipleCrudTests<EmployeeSimple>
{
    protected override IMultipleCrudScenario<EmployeeSimple> GetScenario()
    {
        return new MultipleCrudScenario(Setup.SqlServerConnectionString);
    }
}