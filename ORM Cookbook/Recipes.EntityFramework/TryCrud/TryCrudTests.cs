using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.EntityFramework.Entities;
using Recipes.TryCrud;

namespace Recipes.EntityFramework.TryCrud
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
