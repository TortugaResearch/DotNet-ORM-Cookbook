using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Joins;

namespace Recipes.Ado.Joins
{
    [TestClass]
    public class JoinsTests : JoinsTests<EmployeeDetail, EmployeeSimple>
    {
        protected override IJoinsRepository<EmployeeDetail, EmployeeSimple> GetRepository()
        {
            return new JoinsRepository(Setup.ConnectionString);
        }
    }
}
