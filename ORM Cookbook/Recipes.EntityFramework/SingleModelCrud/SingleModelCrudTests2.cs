using Recipes.EntityFramework.Entities;
using Recipes.SingleModelCrud;

namespace Recipes.EntityFramework.SingleModelCrud;

[TestClass]
public class SingleModelCrudTests2 : SingleModelCrudTests<EmployeeClassification>
{
    protected override ISingleModelCrudScenario<EmployeeClassification> GetScenario()
    {
        return new SingleModelCrudScenario2(Setup.DBContextFactory);
    }
}