using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.NHibernate.Entities;
using Recipes.Joins;

namespace Recipes.NHibernate.Joins
{
    [TestClass]
    public class JoinsTests : JoinsTests<EmployeeDetail, Employee>
    {
        protected override IJoinsRepository<EmployeeDetail, Employee> GetRepository()
        {
            return new JoinsRepository(Setup.SessionFactory);
        }
    }
}
