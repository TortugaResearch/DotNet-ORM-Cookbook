using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.NHibernate.Entities;
using Recipes.Views;

namespace Recipes.NHibernate.Views
{
    [TestClass]
    public class ViewsTests : ViewsTests<EmployeeDetail, Employee>
    {
        protected override IViewsRepository<EmployeeDetail, Employee> GetRepository()
        {
            return new ViewsRepository(Setup.SessionFactory);
        }
    }
}
