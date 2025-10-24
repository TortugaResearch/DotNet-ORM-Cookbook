using Recipes.RepoDB.Models;
using Recipes.Views;

namespace Recipes.RepoDB.Views;

[TestClass]
public class ViewsTests : ViewsTests<EmployeeDetail, EmployeeSimple>
{
    protected override IViewsScenario<EmployeeDetail, EmployeeSimple> GetScenario()
    {
        return new ViewsScenario(Setup.ConnectionString);
    }
}