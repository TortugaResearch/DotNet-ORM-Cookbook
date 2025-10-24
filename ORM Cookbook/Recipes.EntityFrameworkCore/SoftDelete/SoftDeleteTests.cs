using Recipes.EntityFrameworkCore.Entities;
using Recipes.SoftDelete;

namespace Recipes.EntityFrameworkCore.SoftDelete
{
    [TestClass]
    public class SoftDeleteTests : SoftDeleteTests<Department>
    {
        protected override ISoftDeleteScenario<Department> GetScenario()
        {
            return new SoftDeleteScenario(Setup.DBContextWithSoftDelete, Setup.DBContextFactory);
        }
    }
}