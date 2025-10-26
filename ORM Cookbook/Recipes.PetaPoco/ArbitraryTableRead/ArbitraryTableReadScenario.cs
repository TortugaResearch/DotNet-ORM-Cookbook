using Recipes.ArbitraryTableRead;
using System.Data;

namespace Recipes.PetaPoco.ArbitraryTableRead;

public class ArbitraryTableReadScenario : ScenarioBase, IArbitraryTableReadScenario<DataTable>
{
    public ArbitraryTableReadScenario(string connectionString) : base(connectionString)
    { }

    public DataTable GetAll(string schema, string tableName)
    {
        throw new NotImplementedException();
    }
}