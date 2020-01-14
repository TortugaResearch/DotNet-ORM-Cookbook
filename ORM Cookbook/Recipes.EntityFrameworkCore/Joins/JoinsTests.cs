using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.EntityFrameworkCore.Entities;
using Recipes.Joins;

namespace Recipes.EntityFrameworkCore.Joins
{
    [TestClass]
    public class JoinsTests : JoinsTests<EmployeeDetail, Employee>
    {
        protected override IJoinsRepository<EmployeeDetail, Employee> GetRepository()
        {
            return new JoinsRepository(Setup.DBContextFactory);
        }
    }
}
