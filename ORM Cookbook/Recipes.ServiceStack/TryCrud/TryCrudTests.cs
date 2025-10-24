using Recipes.ServiceStack.Entities;
using Recipes.TryCrud;

namespace Recipes.ServiceStack.TryCrud;

[TestClass]
public class TryCrudTests : TryCrudTests<EmployeeClassification>
{
    protected override ITryCrudScenario<EmployeeClassification> GetScenario()
    {
        return new TryCrudScenario(Setup.DbConnectionFactory);
    }
}