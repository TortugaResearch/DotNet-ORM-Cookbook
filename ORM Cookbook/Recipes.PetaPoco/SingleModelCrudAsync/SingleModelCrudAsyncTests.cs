using Recipes.PetaPoco.Models;
using Recipes.SingleModelCrudAsync;

namespace Recipes.PetaPoco.SingleModelCrudAsync;

[TestClass]
public class SingleModelCrudAsyncTests : SingleModelCrudAsyncTests<EmployeeClassification>
{
    protected override ISingleModelCrudAsyncScenario<EmployeeClassification> GetScenario()
    {
        return new SingleModelCrudAsyncScenario(Setup.SqlServerConnectionString);
    }
}