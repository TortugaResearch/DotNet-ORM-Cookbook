using Recipes.SingleColumn;

namespace Recipes.PetaPoco.SingleColumn;

[TestClass]
public class SingleColumnTests : Recipes.SingleColumn.SingleColumnTests
{
    protected override ISingleColumnScenario GetScenario()
    {
        return new SingleColumnScenario(Setup.SqlServerConnectionString);
    }
}