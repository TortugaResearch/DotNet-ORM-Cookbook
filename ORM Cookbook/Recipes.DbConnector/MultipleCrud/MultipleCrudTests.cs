using Recipes.DbConnector.Models;
using Recipes.MultipleCrud;

namespace Recipes.DbConnector.MultipleCrud;

[TestClass]
public class MultipleCrudTests : MultipleCrudTests<EmployeeSimple>
{
    protected override IMultipleCrudScenario<EmployeeSimple> GetScenario()
    {
        return new MultipleCrudScenario(Setup.SqlServerConnectionString);
    }
}