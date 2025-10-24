using Microsoft.EntityFrameworkCore;
using Recipes.ArbitraryTableRead;
using Recipes.EntityFrameworkCore.Entities;
using System.Data;
using System.Data.Common;

namespace Recipes.EntityFrameworkCore.ArbitraryTableRead;

public class ArbitraryTableReadScenario : IArbitraryTableReadScenario<DataTable>
{
    private readonly Func<OrmCookbookContext> CreateDbContext;

    public ArbitraryTableReadScenario(Func<OrmCookbookContext> dBContextFactory)
    {
        CreateDbContext = dBContextFactory;
    }

    public DataTable GetAll(string schema, string tableName)
    {
        using OrmCookbookContext context = CreateDbContext();
        using DbCommand commnd = context.Database.GetDbConnection().CreateCommand();
        string sql = $"SELECT * FROM [{schema}].[{tableName}];";
        commnd.CommandText = sql;
        commnd.Connection!.Open();
        using DbDataReader reader = commnd.ExecuteReader(CommandBehavior.CloseConnection);
        var result = new DataTable();
        result.Load(reader);
        return result;
    }
}