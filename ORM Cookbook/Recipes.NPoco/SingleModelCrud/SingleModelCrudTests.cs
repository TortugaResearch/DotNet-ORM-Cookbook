using Recipes.NPoco.Models;
using Recipes.SingleModelCrud;

namespace Recipes.NPoco.SingleModelCrud;

[TestClass]
public class SingleModelCrudTests : SingleModelCrudTests<EmployeeClassification>
{
    protected override ISingleModelCrudScenario<EmployeeClassification> GetScenario()
    {
        return new SingleModelCrudScenario(Setup.SqlServerConnectionString);
    }
}