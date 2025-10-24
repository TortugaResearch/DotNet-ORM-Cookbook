using Recipes.PopulateDataTable;

namespace Recipes.DbConnector.PopulateDataTable;

[TestClass]
public class PopulateDataTableTests : Recipes.PopulateDataTable.PopulateDataTableTests
{
    protected override IPopulateDataTableScenario GetScenario()
    {
        return new PopulateDataTableScenario(Setup.SqlServerConnectionString);
    }
}