using Recipes.Chain.Models;
using Recipes.ModelWithChildren;

namespace Recipes.Chain.ModelWithChildren;

[TestClass]
public class ModelWithChildrenTests : ModelWithChildrenTests<ProductLine, Product>
{
    protected override IModelWithChildrenScenario<ProductLine, Product> GetScenario()
    {
        return new ModelWithChildrenScenario(Setup.PrimaryDataSource);
    }
}