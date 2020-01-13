using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.EntityFrameworkCore.Entities;
using Recipes.Views;

namespace Recipes.EntityFrameworkCore.Views
{
    [TestClass]
    public class ViewsTests : ViewsTests<EmployeeDetail, Employee>
    {
        protected override IViewsRepository<EmployeeDetail, Employee> GetRepository()
        {
            return new ViewsRepository(Setup.DBContextFactory);
        }
    }
}
