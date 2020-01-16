using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Dapper.Models;
using Recipes.Views;

namespace Recipes.Dapper.Views
{
    [TestClass]
    public class ViewsTests : ViewsTests<EmployeeDetail, EmployeeSimple>
    {
        protected override IViewsScenario<EmployeeDetail, EmployeeSimple> GetScenario()
        {
            return new ViewsScenario(Setup.ConnectionString);
        }
    }
}
