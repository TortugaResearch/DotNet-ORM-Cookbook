using Recipes.Dapper.Models;
using Recipes.SingleModelCrud;

namespace Recipes.Dapper.SingleModelCrud;

[TestClass]
public class SingleModelCrudTests : SingleModelCrudTests<EmployeeClassification>
{
    protected override ISingleModelCrudScenario<EmployeeClassification> GetScenario()
    {
        return new SingleModelCrudScenario(Setup.SqlServerConnectionString);
    }
}