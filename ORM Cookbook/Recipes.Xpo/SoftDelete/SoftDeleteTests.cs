using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.SoftDelete;
using Recipes.Xpo.Entities;

namespace Recipes.Xpo.SoftDelete
{
    [TestClass]
    public class SoftDeleteTests : SoftDeleteTests<Department>
    {
        protected override ISoftDeleteScenario<Department> GetScenario()
        {
            return new SoftDeleteScenario();
        }
    }
}
