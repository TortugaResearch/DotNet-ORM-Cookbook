using Microsoft.Data.SqlClient;

namespace Recipes.Ado;

/// <summary>
/// Base class containing common code used by all ADO scenarios.
/// </summary>
public abstract class SqlServerScenarioBase
{
    readonly string m_ConnectionString;

    public SqlServerScenarioBase(string connectionString)
    {
        m_ConnectionString = connectionString;
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

    /// <summary>
    /// Opens a database connection.
    /// </summary>
    /// <remarks>Caller must dispose the connection.</remarks>
    protected async Task<SqlConnection> OpenConnectionAsync()
    {
        var con = new SqlConnection(m_ConnectionString);
        await con.OpenAsync().ConfigureAwait(false);
        return con;
    }
}