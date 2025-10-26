using Recipes.PetaPoco.Models;
using Recipes.Views;

namespace Recipes.PetaPoco.Views;

[TestClass]
public class ViewsTests : ViewsTests<EmployeeDetail, EmployeeSimple>
{
    protected override IViewsScenario<EmployeeDetail, EmployeeSimple> GetScenario()
    {
        return new ViewsScenario(Setup.SqlServerConnectionString);
    }
}