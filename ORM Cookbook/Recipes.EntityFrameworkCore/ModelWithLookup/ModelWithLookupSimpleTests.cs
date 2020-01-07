using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.EntityFrameworkCore.Entities;
using Recipes.ModelWithLookup;

namespace Recipes.EntityFrameworkCore.ModelWithLookup
{
    [TestClass]
    public class ModelWithLookupSimpleTests : ModelWithLookupSimpleTests<Employee>
    {
        protected override IModelWithLookupSimpleRepository<Employee> GetRepository()
        {
            return new ModelWithLookupSimpleRepository(Setup.DBContextFactory);
        }
    }

    [TestClass]
    public class ModelWithLookupComplexTests : ModelWithLookupComplexTests<Employee>
    {
        protected override IModelWithLookupComplexRepository<Employee> GetRepository()
        {
            return new ModelWithLookupComplexRepository(Setup.DBContextFactory);
        }
    }
}
