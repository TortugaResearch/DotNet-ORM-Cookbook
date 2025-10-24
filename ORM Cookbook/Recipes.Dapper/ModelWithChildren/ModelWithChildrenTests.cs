using Recipes.Dapper.Models;
using Recipes.ModelWithChildren;

namespace Recipes.Dapper.ModelWithChildren;

[TestClass]
public class ModelWithChildrenTests : ModelWithChildrenTests<ProductLine, Product>
{
    protected override IModelWithChildrenScenario<ProductLine, Product> GetScenario()
    {
        return new ModelWithChildrenScenario(Setup.SqlServerConnectionString);
    }
}