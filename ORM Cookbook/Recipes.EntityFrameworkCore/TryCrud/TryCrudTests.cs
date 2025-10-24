using Recipes.EntityFrameworkCore.Entities;
using Recipes.TryCrud;

namespace Recipes.EntityFrameworkCore.TryCrud
{
    [TestClass]
    public class TryCrudTests : TryCrudTests<EmployeeClassification>
    {
        protected override ITryCrudScenario<EmployeeClassification> GetScenario()
        {
            return new TryCrudScenario(Setup.DBContextFactory);
        }
    }
}