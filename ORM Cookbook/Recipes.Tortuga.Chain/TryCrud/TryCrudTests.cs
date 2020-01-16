using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.TryCrud;

namespace Recipes.Chain.TryCrud
{
    [TestClass]
    public class TryCrudTests : TryCrudTests<EmployeeClassification>
    {
        protected override ITryCrudScenario<EmployeeClassification> GetScenario()
        {
            return new TryCrudScenario(Setup.PrimaryDataSource);
        }
    }
}
