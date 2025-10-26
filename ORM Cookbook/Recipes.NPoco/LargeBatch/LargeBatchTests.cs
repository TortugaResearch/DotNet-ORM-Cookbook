using Recipes.NPoco.Models;
using Recipes.LargeBatch;

namespace Recipes.NPoco.LargeBatch;

[TestClass]
public class LargeBatchTests : LargeBatchTests<EmployeeSimple>
{
    protected override ILargeBatchScenario<EmployeeSimple> GetScenario()
    {
        return new LargeBatchScenario(Setup.SqlServerConnectionString);
    }
}