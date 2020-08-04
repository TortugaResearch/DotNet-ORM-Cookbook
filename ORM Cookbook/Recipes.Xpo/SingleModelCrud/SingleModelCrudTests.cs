using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Xpo.Entities;
using Recipes.SingleModelCrud;

namespace Recipes.Xpo.SingleModelCrud
{
    [TestClass]
    public class SingleModelCrudTests : SingleModelCrudTests<EmployeeClassification>
    {
        protected override ISingleModelCrudScenario<EmployeeClassification> GetScenario()
        {
            return new SingleModelCrudScenario();
        }
    }
}
