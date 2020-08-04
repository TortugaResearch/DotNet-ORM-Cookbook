using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Xpo.Entities;
using Recipes.BasicStoredProc;

namespace Recipes.Xpo.BasicStoredProc
{
    [TestClass]
    public class BasicStoredProcTests : BasicStoredProcTests<GetEmployeeClassificationsResult, CountEmployeesByClassificationResult>
    {
        protected override IBasicStoredProcScenario<GetEmployeeClassificationsResult, CountEmployeesByClassificationResult> GetScenario()
        {
            return new BasicStoredProcScenario();
        }
    }
}
