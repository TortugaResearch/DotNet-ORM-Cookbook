using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.NHibernate.Entities;
using Recipes.Views;

namespace Recipes.NHibernate.Views
{
    [TestClass]
    public class ViewsTests : ViewsTests<EmployeeDetail, Employee>
    {
        protected override IViewsScenario<EmployeeDetail, Employee> GetScenario()
        {
            return new ViewsScenario(Setup.SessionFactory);
        }
    }
}
