using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.ServiceStack.Entities;
using Recipes.Views;

namespace Recipes.ServiceStack.Views
{
    [TestClass]
    public class ViewsTests : ViewsTests<EmployeeDetail, Employee>
    {
        protected override IViewsRepository<EmployeeDetail, Employee> GetRepository()
        {
            return new ViewsRepository(Setup.DbConnectionFactory);
        }
    }
}
