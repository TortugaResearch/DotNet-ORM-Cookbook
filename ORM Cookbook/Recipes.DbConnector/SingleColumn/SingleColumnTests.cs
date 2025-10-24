using Recipes.SingleColumn;

namespace Recipes.DbConnector.SingleColumn;

[TestClass]
public class SingleColumnTests : Recipes.SingleColumn.SingleColumnTests
{
    protected override ISingleColumnScenario GetScenario()
    {
        return new SingleColumnScenario(Setup.SqlServerConnectionString);
    }
}