using Npgsql;
using System.Threading.Tasks;

namespace Recipes.Ado
{
    /// <summary>
    /// Base class containing common code used by all ADO scenarios.
    /// </summary>
    public abstract class PostgreSqlScenarioBase
    {
        readonly string m_ConnectionString;

        public PostgreSqlScenarioBase(string connectionString)
        {
            m_ConnectionString = connectionString;
        }

        /// <summary>
        /// Opens a database connection.
        /// </summary>
        /// <remarks>Caller must dispose the connection.</remarks>
        protected NpgsqlConnection OpenConnection()
        {
            var con = new NpgsqlConnection(m_ConnectionString);
            con.Open();
            return con;
        }

        /// <summary>
        /// Opens a database connection.
        /// </summary>
        /// <remarks>Caller must dispose the connection.</remarks>
        protected async Task<NpgsqlConnection> OpenConnectionAsync()
        {
            var con = new NpgsqlConnection(m_ConnectionString);
            await con.OpenAsync().ConfigureAwait(false);
            return con;
        }
    }
}
