using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.LinqToDB.Entities;
using Recipes.Views;

namespace Recipes.LinqToDB.Views
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
