using Dapper;
using Recipes.ArbitraryTableRead;
using System.Data;

namespace Recipes.Dapper.ArbitraryTableRead;

public class ArbitraryTableReadScenario : ScenarioBase, IArbitraryTableReadScenario<DataTable>
{
    public ArbitraryTableReadScenario(string connectionString) : base(connectionString)
    { }

    public DataTable GetAll(string schema, string tableName)
    {
        //WARNING: Verify that the schema and table name exist to avoid SQL injection attacks.
        string sql = $"SELECT * FROM [{schema}].[{tableName}];";

        var result = new DataTable();

        using (var con = OpenConnection())
        using (var reader = con.ExecuteReader(sql))
            result.Load(reader);

        return result;
    }
}