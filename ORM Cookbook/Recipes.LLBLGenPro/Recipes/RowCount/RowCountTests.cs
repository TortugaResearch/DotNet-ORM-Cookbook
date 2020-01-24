using LLBLGenPro.OrmCookbook.EntityClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.LLBLGenPro;
using Recipes.RowCount;

namespace Recipes.LLBLGenPro.RowCount
{
    [TestClass]
    public class RowCountTests : RowCountTests<EmployeeEntity>
    {
        protected override IRowCountScenario<EmployeeEntity> GetScenario()
        {
            return new RowCountScenario();
        }
    }
}
