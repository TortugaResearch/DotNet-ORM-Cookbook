using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.SoftDelete;
using Recipes.EntityFramework.Entities;

namespace Recipes.EntityFramework.SoftDelete
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
