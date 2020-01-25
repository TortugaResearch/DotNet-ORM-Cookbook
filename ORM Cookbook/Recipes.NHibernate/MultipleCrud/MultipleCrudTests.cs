using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.MultipleCrud;
using Recipes.NHibernate.Entities;

namespace Recipes.NHibernate.MultipleCrud
{
    [TestClass]
    public class MultipleCrudTests : MultipleCrudTests<Employee>
    {
        protected override IMultipleCrudScenario<Employee> GetScenario()
        {
            return new MultipleCrudScenario(Setup.SessionFactory);
        }
    }
}
