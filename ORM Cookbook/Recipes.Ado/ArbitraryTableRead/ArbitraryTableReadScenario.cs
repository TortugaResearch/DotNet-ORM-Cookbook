using Microsoft.Data.SqlClient;
using Recipes.ArbitraryTableRead;
using System.Data;

namespace Recipes.Ado.ArbitraryTableRead;

public class ArbitraryTableReadScenario : SqlServerScenarioBase, IArbitraryTableReadScenario<DataTable>
{
    public ArbitraryTableReadScenario(string connectionString) : base(connectionString)
    { }

    public DataTable GetAll(string schema, string tableName)
    {
        //WARNING: Verify that the schema and table name exist to avoid SQL injection attacks.
        string sql = $"SELECT * FROM [{schema}].[{tableName}];";

        var result = new DataTable();

        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        using (var reader = cmd.ExecuteReader())
            result.Load(reader);

        return result;
    }
}
