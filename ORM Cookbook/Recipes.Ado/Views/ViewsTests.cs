using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Views;

namespace Recipes.Ado.Views
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
