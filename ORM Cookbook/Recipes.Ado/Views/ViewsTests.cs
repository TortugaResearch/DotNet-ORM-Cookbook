using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Ado.Models;
using Recipes.Views;

namespace Recipes.Ado.Views
{
    [TestClass]
    public class ViewsTests : ViewsTests<EmployeeDetail, EmployeeSimple>
    {
        protected override IViewsScenario<EmployeeDetail, EmployeeSimple> GetScenario()
        {
            return new ViewsScenario(Setup.SqlServerConnectionString);
        }
    }
}
