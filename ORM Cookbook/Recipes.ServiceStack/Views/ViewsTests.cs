using Recipes.ServiceStack.Entities;
using Recipes.Views;

namespace Recipes.ServiceStack.Views;

[TestClass]
public class ViewsTests : ViewsTests<EmployeeDetail, Employee>
{
    protected override IViewsScenario<EmployeeDetail, Employee> GetScenario()
    {
        return new ViewsScenario(Setup.DbConnectionFactory);
    }
}