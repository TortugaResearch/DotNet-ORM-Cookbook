using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.LargeBatch;
using Recipes.NHibernate.Entities;

namespace Recipes.NHibernate.LargeBatch
{
    [TestClass]
    public class LargeBatchTests : LargeBatchTests<Employee>
    {
        protected override ILargeBatchScenario<Employee> GetScenario()
        {
            return new LargeBatchScenario(Setup.SessionFactory);
        }
    }
}
