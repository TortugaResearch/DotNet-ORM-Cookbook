using LLBLGenPro.OrmCookbook.EntityClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Views;

namespace Recipes.LLBLGenPro.Views
{
    [TestClass]
    public class ViewsTests : ViewsTests<EmployeeDetailEntity, EmployeeEntity>
    {
        protected override IViewsScenario<EmployeeDetailEntity, EmployeeEntity> GetScenario()
        {
            return new ViewsScenario();
        }
    }
}
