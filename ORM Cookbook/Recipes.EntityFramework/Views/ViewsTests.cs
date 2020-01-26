using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.EntityFramework.Entities;
using Recipes.Views;

namespace Recipes.EntityFramework.Views
{
    [TestClass]
    public class ViewsTests : ViewsTests<EmployeeDetail, Employee>
    {
        protected override IViewsScenario<EmployeeDetail, Employee> GetScenario()
        {
            return new ViewsScenario(Setup.DBContextFactory);
        }
    }
}
