using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Xpo.Entities;
using Recipes.MultipleCrud;

namespace Recipes.Xpo.MultipleCrud
{
    [TestClass]
    public class MultipleCrudTests : MultipleCrudTests<Employee>
    {
        protected override IMultipleCrudScenario<Employee> GetScenario()
        {
            return new MultipleCrudScenario();
        }
    }
}
