using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.NHibernate.Entities;
using Recipes.Pagination;

namespace Recipes.NHibernate.Pagination
{
    [TestClass]
    public class PaginationTests : PaginationTests<Employee>
    {
        protected override IPaginationScenario<Employee> GetScenario()
        {
            return new PaginationScenario(Setup.SessionFactory);
        }
    }
}
