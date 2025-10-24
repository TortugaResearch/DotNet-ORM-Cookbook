using Recipes.ArbitraryTableRead;
using System.Data;

namespace Recipes.Chain.ArbitraryTableRead;

[TestClass]
public class ArbitraryTableReadTests : ArbitraryTableReadTests<DataTable>
{
    protected override IArbitraryTableReadScenario<DataTable> GetScenario()
    {
        return new ArbitraryTableReadScenario(Setup.PrimaryDataSource);
    }
}

[TestClass]
public class ArbitraryTableReadTests2 : ArbitraryTableReadTests<IReadOnlyList<IReadOnlyDictionary<string, object?>>>
{
    protected override IArbitraryTableReadScenario<IReadOnlyList<IReadOnlyDictionary<string, object?>>> GetScenario()
    {
        return new ArbitraryTableReadScenario2(Setup.PrimaryDataSource);
    }
}