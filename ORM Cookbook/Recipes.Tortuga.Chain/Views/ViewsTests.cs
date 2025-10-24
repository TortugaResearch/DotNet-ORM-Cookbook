using Recipes.Chain.Models;
using Recipes.Views;

namespace Recipes.Chain.Views
{
    [TestClass]
    public class ViewsTests : ViewsTests<EmployeeDetail, EmployeeSimple>
    {
        protected override IViewsScenario<EmployeeDetail, EmployeeSimple> GetScenario()
        {
            return new ViewsScenario(Setup.PrimaryDataSource);
        }
    }
}