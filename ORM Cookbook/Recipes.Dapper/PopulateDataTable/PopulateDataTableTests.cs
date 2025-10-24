using Recipes.PopulateDataTable;

namespace Recipes.Dapper.PopulateDataTable;

[TestClass]
public class PopulateDataTableTests : Recipes.PopulateDataTable.PopulateDataTableTests
{
    protected override IPopulateDataTableScenario GetScenario()
    {
        return new PopulateDataTableScenario(Setup.SqlServerConnectionString);
    }
}