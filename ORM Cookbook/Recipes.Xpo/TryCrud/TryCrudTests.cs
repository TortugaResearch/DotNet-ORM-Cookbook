using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Xpo.Entities;
using Recipes.TryCrud;

namespace Recipes.Xpo.TryCrud
{
    [TestClass]
    public class TryCrudTests : TryCrudTests<EmployeeClassification>
    {
        protected override ITryCrudScenario<EmployeeClassification> GetScenario()
        {
            return new TryCrudScenario();
        }
    }
}
