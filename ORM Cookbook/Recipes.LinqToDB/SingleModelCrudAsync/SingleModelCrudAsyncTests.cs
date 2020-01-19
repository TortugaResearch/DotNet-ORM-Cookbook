using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.LinqToDB.Entities;
using Recipes.SingleModelCrudAsync;

namespace Recipes.LinqToDB.SingleModelCrudAsync
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
