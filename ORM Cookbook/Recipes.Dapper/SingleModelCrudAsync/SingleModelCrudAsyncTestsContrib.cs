using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Dapper.Models;
using Recipes.SingleModelCrudAsync;

namespace Recipes.Dapper.SingleModelCrudAsync
{
    [TestClass]
    public class SingleModelCrudAsyncTestsContrib : SingleModelCrudAsyncTests<EmployeeClassification>
    {
        protected override ISingleModelCrudAsyncScenario<EmployeeClassification> GetScenario()
        {
            return new SingleModelCrudAsyncScenarioContrib(Setup.ConnectionString);
        }
    }
}
