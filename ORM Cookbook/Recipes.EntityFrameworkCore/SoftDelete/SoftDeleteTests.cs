using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.SoftDelete;
using Recipes.EntityFrameworkCore.Entities;

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
