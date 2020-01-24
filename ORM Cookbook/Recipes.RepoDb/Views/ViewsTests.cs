using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.RepoDb.Models;
using Recipes.Views;

namespace Recipes.RepoDb.Views
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
