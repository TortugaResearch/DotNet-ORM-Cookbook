using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.RepoDb.Entities;
using Recipes.SingleModelCrudAsync;

namespace Recipes.RepoDb.SingleModelCrudAsync
{
    [TestClass]
    public class SingleModelCrudAsyncTests : SingleModelCrudAsyncTests<EmployeeClassificationSingleModelCrudAsync>
    {
        protected override ISingleModelCrudAsyncScenario<EmployeeClassificationSingleModelCrudAsync> GetScenario()
        {
            return new SingleModelCrudAsyncScenario(Setup.ConnectionString);
        }
    }
}
