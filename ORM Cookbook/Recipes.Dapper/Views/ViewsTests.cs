using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Views;

namespace Recipes.Dapper.Views
{
    [TestClass]
    public class ViewsTests : ViewsTests<EmployeeDetail, EmployeeSimple>
    {
        protected override IViewsRepository<EmployeeDetail, EmployeeSimple> GetRepository()
        {
            return new ViewsRepository(Setup.ConnectionString);
        }
    }
}
