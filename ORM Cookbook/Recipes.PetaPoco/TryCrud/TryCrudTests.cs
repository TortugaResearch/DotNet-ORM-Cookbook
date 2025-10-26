using Recipes.PetaPoco.Models;
using Recipes.TryCrud;

namespace Recipes.PetaPoco.TryCrud;

[TestClass]
public class TryCrudTests : TryCrudTests<EmployeeClassification>
{
    protected override ITryCrudScenario<EmployeeClassification> GetScenario()
    {
        return new TryCrudScenario(Setup.SqlServerConnectionString);
    }
}