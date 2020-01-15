using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.ModelWithChildren;

namespace Recipes.Ado.ModelWithChildren
{
    [TestClass]
    public class ModelWithChildrenTests : ModelWithChildrenTests<ProductLine, Product>
    {
        protected override IModelWithChildrenRepository<ProductLine, Product> GetRepository()
        {
            return new ModelWithChildrenRepository(Setup.ConnectionString);
        }
    }
}
