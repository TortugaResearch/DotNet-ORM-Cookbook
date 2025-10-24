using Recipes.EntityFramework.Entities;
using Recipes.SoftDelete;

namespace Recipes.EntityFramework.SoftDelete;

[TestClass]
public class SoftDeleteTests : SoftDeleteTests<Department>
{
    protected override ISoftDeleteScenario<Department> GetScenario()
    {
        return new SoftDeleteScenario(Setup.DBContextWithSoftDelete, Setup.DBContextFactory);
    }
}