using Recipes.EntityFrameworkCore.Entities;
using Recipes.SingleModelCrud;

namespace Recipes.EntityFrameworkCore.SingleModelCrud
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