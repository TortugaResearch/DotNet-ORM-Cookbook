using LLBLGenPro.OrmCookbook.EntityClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.ModelWithChildren;

namespace Recipes.LLBLGenPro.ModelWithChildren
{
    [TestClass]
    public class ModelWithChildrenTests : ModelWithChildrenTests<ProductLineEntity, ProductEntity>
    {
        protected override IModelWithChildrenRepository<ProductLineEntity, ProductEntity> GetRepository()
        {
            return new ModelWithChildrenRepository();
        }
    }
}
