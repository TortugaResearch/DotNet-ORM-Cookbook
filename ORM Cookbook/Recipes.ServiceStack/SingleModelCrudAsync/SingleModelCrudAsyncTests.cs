using Recipes.ServiceStack.Entities;
using Recipes.SingleModelCrudAsync;

namespace Recipes.ServiceStack.SingleModelCrudAsync;

[TestClass]
public class SingleModelCrudAsyncTests : SingleModelCrudAsyncTests<EmployeeClassification>
{
    protected override ISingleModelCrudAsyncScenario<EmployeeClassification> GetScenario()
    {
        return new SingleModelCrudAsyncScenario(Setup.DbConnectionFactory);
    }
}