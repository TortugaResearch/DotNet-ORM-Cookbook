using Recipes.Ado.Models;
using Recipes.TryCrud;

namespace Recipes.Ado.TryCrud;

[TestClass]
public class TryCrudTests : TryCrudTests<EmployeeClassification>
{
    protected override ITryCrudScenario<EmployeeClassification> GetScenario()
    {
        return new TryCrudScenario(Setup.SqlServerConnectionString);
    }
}