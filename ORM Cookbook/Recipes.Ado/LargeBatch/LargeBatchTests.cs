using Recipes.Ado.Models;
using Recipes.LargeBatch;

namespace Recipes.Ado.LargeBatch;

[TestClass]
public class LargeBatchTests : LargeBatchTests<EmployeeSimple>
{
    protected override ILargeBatchScenario<EmployeeSimple> GetScenario()
    {
        return new LargeBatchScenario(Setup.SqlServerConnectionString);
    }
}