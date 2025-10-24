using Recipes.EntityFrameworkCore.Entities;
using Recipes.LargeBatch;

namespace Recipes.EntityFrameworkCore.LargeBatch;

[TestClass]
public class LargeBatchTests : LargeBatchTests<Employee>
{
    protected override ILargeBatchScenario<Employee> GetScenario()
    {
        return new LargeBatchScenario(Setup.DBContextFactory);
    }
}