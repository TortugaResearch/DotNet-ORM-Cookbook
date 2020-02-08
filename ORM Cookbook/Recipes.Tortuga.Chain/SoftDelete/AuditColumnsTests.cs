using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.SoftDelete;
using Recipes.Chain.Models;

namespace Recipes.Chain.SoftDelete
{
    [TestClass]
    public class SoftDeleteTests : SoftDeleteTests<Department>
    {
        protected override ISoftDeleteScenario<Department> GetScenario()
        {
            return new SoftDeleteScenario(Setup.PrimaryDataSource);
        }
    }
}
