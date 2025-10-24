using Recipes.ModelWithChildren;
using Recipes.ServiceStack.Entities;

namespace Recipes.ServiceStack.ModelWithChildren;

[TestClass]
public class ModelWithChildrenTests : ModelWithChildrenTests<ProductLine, Product>
{
    protected override IModelWithChildrenScenario<ProductLine, Product> GetScenario()
    {
        return new ModelWithChildrenScenario(Setup.DbConnectionFactory);
    }
}