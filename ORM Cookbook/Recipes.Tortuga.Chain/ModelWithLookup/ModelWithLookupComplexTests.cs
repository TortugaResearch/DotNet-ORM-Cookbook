using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.ModelWithLookup;

namespace Recipes.Chain.ModelWithLookup
{
    [TestClass]
    public class ModelWithLookupComplexTests : ModelWithLookupComplexTests<EmployeeComplex>
    {
        protected override IModelWithLookupComplexRepository<EmployeeComplex> GetRepository()
        {
            return new ModelWithLookupComplexRepository(Setup.PrimaryDataSource);
        }
    }
}
