using LLBLGenPro.OrmCookbook.EntityClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Joins;

namespace Recipes.LLBLGenPro.Joins
{
    [TestClass]
    public class JoinsTests : JoinsTests<EmployeeDetailEntity, EmployeeEntity>
    {
        protected override IJoinsRepository<EmployeeDetailEntity, EmployeeEntity> GetRepository()
        {
            return new JoinsRepository();
        }
    }
}
