using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.DbConnector.Models;
using Recipes.BasicStoredProc;

namespace Recipes.DbConnector.BasicStoredProc
{
    [TestClass]
    public class BasicStoredProcTests : BasicStoredProcTests<EmployeeClassification, EmployeeClassificationWithCount>
    {
        protected override IBasicStoredProcScenario<EmployeeClassification, EmployeeClassificationWithCount> GetScenario()
        {
            return new BasicStoredProcScenario(Setup.SqlServerConnectionString);
        }
    }
}
