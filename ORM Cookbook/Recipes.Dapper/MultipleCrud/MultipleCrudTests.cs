using Recipes.Dapper.Models;
using Recipes.MultipleCrud;

namespace Recipes.Dapper.MultipleCrud;

[TestClass]
public class MultipleCrudTests : MultipleCrudTests<EmployeeSimple>
{
    protected override IMultipleCrudScenario<EmployeeSimple> GetScenario()
    {
        return new MultipleCrudScenario(Setup.SqlServerConnectionString);
    }
}