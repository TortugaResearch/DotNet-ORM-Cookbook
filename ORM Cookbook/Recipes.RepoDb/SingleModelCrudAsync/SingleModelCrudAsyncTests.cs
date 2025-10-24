using Recipes.RepoDB.Models;
using Recipes.SingleModelCrudAsync;

namespace Recipes.RepoDB.SingleModelCrudAsync;

[TestClass]
public class SingleModelCrudAsyncTests : SingleModelCrudAsyncTests<EmployeeClassification>
{
    protected override ISingleModelCrudAsyncScenario<EmployeeClassification> GetScenario()
    {
        return new SingleModelCrudAsyncScenario(Setup.ConnectionString);
    }
}