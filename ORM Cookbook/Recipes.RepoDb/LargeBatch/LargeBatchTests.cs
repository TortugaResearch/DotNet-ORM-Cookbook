using Recipes.LargeBatch;
using Recipes.RepoDB.Models;

namespace Recipes.RepoDB.LargeBatch;

[TestClass]
public class LargeBatchTests : LargeBatchTests<EmployeeSimple>
{
    protected override ILargeBatchScenario<EmployeeSimple> GetScenario()
    {
        return new LargeBatchScenario(Setup.ConnectionString);
    }
}