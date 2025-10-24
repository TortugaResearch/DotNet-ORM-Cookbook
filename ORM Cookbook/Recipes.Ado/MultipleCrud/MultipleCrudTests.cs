using Recipes.Ado.Models;
using Recipes.MultipleCrud;

namespace Recipes.Ado.MultipleCrud;

[TestClass]
public class MultipleCrudTests : MultipleCrudTests<EmployeeSimple>
{
    protected override IMultipleCrudScenario<EmployeeSimple> GetScenario()
    {
        return new MultipleCrudScenario(Setup.SqlServerConnectionString);
    }
}