using Recipes.PetaPoco.Models;
using Recipes.SingleModelCrud;

namespace Recipes.PetaPoco.SingleModelCrud;

[TestClass]
public class SingleModelCrudTests : SingleModelCrudTests<EmployeeClassification>
{
    protected override ISingleModelCrudScenario<EmployeeClassification> GetScenario()
    {
        return new SingleModelCrudScenario(Setup.SqlServerConnectionString);
    }
}