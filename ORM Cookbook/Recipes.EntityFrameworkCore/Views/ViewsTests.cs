using Recipes.EntityFrameworkCore.Entities;
using Recipes.Views;

namespace Recipes.EntityFrameworkCore.Views;

[TestClass]
public class ViewsTests : ViewsTests<EmployeeDetail, Employee>
{
    protected override IViewsScenario<EmployeeDetail, Employee> GetScenario()
    {
        return new ViewsScenario(Setup.DBContextFactory);
    }
}