using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.BasicStoredProc;
using Recipes.RepoDb.Models;

namespace Recipes.RepoDb.BasicStoredProc
{
    [TestClass]
    public class BasicStoredProcTests : BasicStoredProcTests<EmployeeClassification, EmployeeClassificationWithCount>
    {
        protected override IBasicStoredProcScenario<EmployeeClassification, EmployeeClassificationWithCount> GetScenario()
        {
            return new BasicStoredProcScenario(Setup.ConnectionString);
        }
    }
}
