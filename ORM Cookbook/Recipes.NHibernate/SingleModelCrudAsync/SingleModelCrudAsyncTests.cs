using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.NHibernate.Entities;
using Recipes.SingleModelCrudAsync;

namespace Recipes.NHibernate.SingleModelCrudAsync
{
    [TestClass]
    public class SingleModelCrudAsyncTests : SingleModelCrudAsyncTests<EmployeeClassification>
    {
        protected override ISingleModelCrudAsyncScenario<EmployeeClassification> GetScenario()
        {
            return new SingleModelCrudAsyncScenario(Setup.SessionFactory);
        }
    }
}
