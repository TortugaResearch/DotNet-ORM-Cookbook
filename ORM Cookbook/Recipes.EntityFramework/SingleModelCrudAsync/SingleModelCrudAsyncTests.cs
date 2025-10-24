using Recipes.EntityFramework.Entities;
using Recipes.SingleModelCrudAsync;

namespace Recipes.EntityFramework.SingleModelCrudAsync;

[TestClass]
public class SingleModelCrudAsyncTests : SingleModelCrudAsyncTests<EmployeeClassification>
{
    protected override ISingleModelCrudAsyncScenario<EmployeeClassification> GetScenario()
    {
        return new SingleModelCrudAsyncScenario(Setup.DBContextFactory);
    }
}