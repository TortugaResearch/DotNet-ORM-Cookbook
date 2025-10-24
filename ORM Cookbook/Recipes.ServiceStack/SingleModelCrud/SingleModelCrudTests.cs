using Recipes.ServiceStack.Entities;
using Recipes.SingleModelCrud;

namespace Recipes.ServiceStack.SingleModelCrud;

[TestClass]
public class SingleModelCrudTests : SingleModelCrudTests<EmployeeClassification>
{
    protected override ISingleModelCrudScenario<EmployeeClassification> GetScenario()
    {
        return new SingleModelCrudScenario(Setup.DbConnectionFactory);
    }
}