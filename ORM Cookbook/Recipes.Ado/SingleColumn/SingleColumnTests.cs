using Recipes.SingleColumn;

namespace Recipes.Ado.SingleColumn;

[TestClass]
public class SingleColumnTests : Recipes.SingleColumn.SingleColumnTests
{
    protected override ISingleColumnScenario GetScenario()
    {
        return new SingleColumnScenario(Setup.SqlServerConnectionString);
    }
}