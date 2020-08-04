using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Xpo.Entities;
using Recipes.SingleModelCrudAsync;

namespace Recipes.Xpo.SingleModelCrudAsync
{
    [TestClass]
    public class SingleModelCrudAsyncTests : SingleModelCrudAsyncTests<EmployeeClassification>
    {
        protected override ISingleModelCrudAsyncScenario<EmployeeClassification> GetScenario()
        {
            return new SingleModelCrudAsyncScenario();
        }
    }
}
