using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.RepoDb.Models;
using Recipes.MultipleCrud;

namespace Recipes.RepoDb.MultipleCrud
{
    [TestClass]
    public class MultipleCrudTests : MultipleCrudTests<EmployeeSimple>
    {
        protected override IMultipleCrudScenario<EmployeeSimple> GetScenario()
        {
            return new MultipleCrudScenario(Setup.ConnectionString);
        }
    }
}
