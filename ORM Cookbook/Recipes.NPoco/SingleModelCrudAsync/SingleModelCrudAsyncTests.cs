using Recipes.NPoco.Models;
using Recipes.SingleModelCrudAsync;

namespace Recipes.NPoco.SingleModelCrudAsync;

[TestClass]
public class SingleModelCrudAsyncTests : SingleModelCrudAsyncTests<EmployeeClassification>
{
    protected override ISingleModelCrudAsyncScenario<EmployeeClassification> GetScenario()
    {
        return new SingleModelCrudAsyncScenario(Setup.SqlServerConnectionString);
    }
}