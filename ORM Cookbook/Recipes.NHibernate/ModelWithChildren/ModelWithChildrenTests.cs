using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.ModelWithChildren;
using Recipes.NHibernate.Entities;

namespace Recipes.NHibernate.ModelWithChildren
{
    [TestClass]
    public class ModelWithChildrenTests : ModelWithChildrenTests<ProductLine, Product>
    {
        protected override IModelWithChildrenRepository<ProductLine, Product> GetRepository()
        {
            return new ModelWithChildrenRepository(Setup.SessionFactory);
        }
    }
}
