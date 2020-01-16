using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Joins;
using Recipes.NHibernate.Entities;

namespace Recipes.NHibernate.Joins
{
    [TestClass]
    public class JoinsTests : JoinsTests<EmployeeDetail, Employee>
    {
        protected override IJoinsScenario<EmployeeDetail, Employee> GetScenario()
        {
            return new JoinsScenario(Setup.SessionFactory);
        }
    }
}
