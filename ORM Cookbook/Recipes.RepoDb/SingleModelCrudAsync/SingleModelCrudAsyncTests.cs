using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.RepoDb.Models;
using Recipes.SingleModelCrudAsync;

namespace Recipes.RepoDb.SingleModelCrudAsync
{
    [TestClass]
    public class SingleModelCrudAsyncTests : SingleModelCrudAsyncTests<EmployeeClassification>
    {
        protected override ISingleModelCrudAsyncScenario<EmployeeClassification> GetScenario()
        {
            return new SingleModelCrudAsyncScenario(Setup.ConnectionString);
        }
    }
}
