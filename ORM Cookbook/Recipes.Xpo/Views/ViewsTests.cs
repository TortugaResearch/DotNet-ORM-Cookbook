using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Xpo.Entities;
using Recipes.Views;

namespace Recipes.Xpo.Views
{
    [TestClass]
    public class ViewsTests : ViewsTests<EmployeeDetail, Employee>
    {
        protected override IViewsScenario<EmployeeDetail, Employee> GetScenario()
        {
            return new ViewsScenario();
        }
    }
}
