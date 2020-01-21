using LLBLGenPro.OrmCookbook.TypedViewClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.BasicStoredProc;

namespace Recipes.LLBLGenPro.BasicStoredProc
{
    [TestClass]
    public class BasicStoredProcTests : BasicStoredProcTests<GetEmployeeClassificationsResultRow, CountEmployeesByClassificationResultRow>
    {
        protected override IBasicStoredProcScenario<GetEmployeeClassificationsResultRow, CountEmployeesByClassificationResultRow> GetScenario()
        {
            return new BasicStoredProcScenario();
        }
    }
}
