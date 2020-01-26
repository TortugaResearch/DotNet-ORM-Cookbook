using System.Data;
using ServiceStack.Data;

namespace Recipes.ServiceStack
{
    /// <summary>
    /// Base class containing common code used by all ServiceStack scenarios.
    /// </summary>
    public abstract class ScenarioBase
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        protected ScenarioBase(IDbConnectionFactory dbConnectionFactory)
        {
            this._dbConnectionFactory = dbConnectionFactory;
        }

        /// <summary>
        /// Opens a database connection.
        /// </summary>
        /// <remarks>Caller must dispose the connection.</remarks>
        protected IDbConnection OpenConnection()
        {
            return _dbConnectionFactory.OpenDbConnection();
        }
    }
}
