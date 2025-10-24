using Recipes.ArbitraryTableRead;
using System.Data;

namespace Recipes.EntityFrameworkCore.ArbitraryTableRead;

[TestClass]
public class ArbitraryTableReadTests : ArbitraryTableReadTests<DataTable>
{
    protected override IArbitraryTableReadScenario<DataTable> GetScenario()
    {
        return new ArbitraryTableReadScenario(Setup.DBContextFactory);
    }
}