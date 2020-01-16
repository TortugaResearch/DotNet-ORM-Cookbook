using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.NHibernate.Entities;
using Recipes.SingleModelCrud;

namespace Recipes.NHibernate.SingleModelCrud
{
    [TestClass]
    public class SingleModelCrudTests : SingleModelCrudTests<EmployeeClassification>
    {
        protected override ISingleModelCrudScenario<EmployeeClassification> GetScenario()
        {
            return new SingleModelCrudScenario(Setup.SessionFactory);
        }
    }
}
