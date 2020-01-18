using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Chain.Models;
using Recipes.BasicStoredProc;

namespace Recipes.Chain.BasicStoredProc
{
    [TestClass]
    public class BasicStoredProcTests : BasicStoredProcTests<EmployeeClassification, EmployeeClassificationWithCount>
    {
        protected override IBasicStoredProcScenario<EmployeeClassification, EmployeeClassificationWithCount> GetScenario()
        {
            return new BasicStoredProcScenario(Setup.PrimaryDataSource);
        }
    }
}
