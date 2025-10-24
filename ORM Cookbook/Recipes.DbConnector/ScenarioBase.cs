using DbConnector.Core;
using Microsoft.Data.SqlClient;

namespace Recipes.DbConnector;

/// <summary>
/// Base class containing common code used by all ADO scenarios.
/// </summary>
public abstract class ScenarioBase
{
    readonly string m_ConnectionString;
    protected IDbConnector DbConnector { get; }



    public ScenarioBase(string connectionString)
    {
        m_ConnectionString = connectionString;
        DbConnector = new DbConnector<SqlConnection>(connectionString);
    }



    /// <summary>
    /// Opens a database connection.
    /// </summary>
    /// <remarks>Caller must dispose the connection.</remarks>
    protected SqlConnection OpenConnection()
    {
        var con = new SqlConnection(m_ConnectionString);
        con.Open();
        return con;
    }
}
