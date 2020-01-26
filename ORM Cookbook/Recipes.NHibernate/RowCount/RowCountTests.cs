using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.NHibernate.Entities;
using Recipes.RowCount;

namespace Recipes.NHibernate.RowCount
{
    [TestClass]
    public class RowCountTests : RowCountTests<Employee>
    {
        protected override IRowCountScenario<Employee> GetScenario()
        {
            return new RowCountScenario(Setup.SessionFactory);
        }
    }
}
