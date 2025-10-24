using Recipes.RepoDB.Models;
using Recipes.SingleModelCrud;

namespace Recipes.RepoDB.SingleModelCrud;

[TestClass]
public class SingleModelCrudTests : SingleModelCrudTests<EmployeeClassification>
{
    protected override ISingleModelCrudScenario<EmployeeClassification> GetScenario()
    {
        return new SingleModelCrudScenario(Setup.ConnectionString);
    }
}