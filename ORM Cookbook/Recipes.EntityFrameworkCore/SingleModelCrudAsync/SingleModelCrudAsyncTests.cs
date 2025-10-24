using Recipes.EntityFrameworkCore.Entities;
using Recipes.SingleModelCrudAsync;

namespace Recipes.EntityFrameworkCore.SingleModelCrudAsync
{
    [TestClass]
    public class SingleModelCrudAsyncTests : SingleModelCrudAsyncTests<EmployeeClassification>
    {
        protected override ISingleModelCrudAsyncScenario<EmployeeClassification> GetScenario()
        {
            return new SingleModelCrudAsyncScenario(Setup.DBContextFactory);
        }
    }
}