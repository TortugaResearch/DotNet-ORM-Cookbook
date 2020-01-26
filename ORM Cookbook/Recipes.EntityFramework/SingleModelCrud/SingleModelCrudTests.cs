using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.EntityFramework.Entities;
using Recipes.SingleModelCrud;

namespace Recipes.EntityFramework.SingleModelCrud
{
    [TestClass]
    public class SingleModelCrudTests : SingleModelCrudTests<EmployeeClassification>
    {
        protected override ISingleModelCrudScenario<EmployeeClassification> GetScenario()
        {
            return new SingleModelCrudScenario(Setup.DBContextFactory);
        }
    }
}
