using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.ModelWithChildren;
using Recipes.RepoDb.Models;

namespace Recipes.RepoDb.ModelWithChildren
{
    [TestClass]
    public class ModelWithChildrenTests : ModelWithChildrenTests<ProductLine, Product>
    {
        protected override IModelWithChildrenScenario<ProductLine, Product> GetScenario()
        {
            return new ModelWithChildrenScenario(Setup.ConnectionString);
        }
    }
}
