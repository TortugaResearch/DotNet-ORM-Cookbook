using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.Linq;
using SD.LLBLGen.Pro.DQE.SqlServer;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.Tools.OrmProfiler.Interceptor;

namespace Recipes.LLBLGenPro
{
    [TestClass]
    public class Setup
    {
        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
        }

        [AssemblyInitialize]
        [SuppressMessage("Usage", "CA1801")]
        public static void AssemblyInit(TestContext context)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory).AddJsonFile("appsettings.json").Build();
            var sqlServerConnectionString = configuration.GetSection("ConnectionStrings")["SqlServerTestDatabase"];
            RuntimeConfiguration.AddConnectionString("ConnectionString.SQL Server (SqlClient)", sqlServerConnectionString);
			// wrap the factory with the orm profiler's factory so we get real time query interception and can see what's going on.
			// ORM Profiler is a free tool for every LLBLGen Pro customer.
            RuntimeConfiguration.ConfigureDQE<SQLServerDQEConfiguration>(c => c.AddDbProviderFactory(InterceptorCore.Initialize("ORM CookBook",
																																typeof(Microsoft.Data.SqlClient.SqlClientFactory)))
                                                                               .SetDefaultCompatibilityLevel(SqlServerCompatibilityLevel.SqlServer2012));
            RuntimeConfiguration.Entity.SetMarkSavedEntitiesAsFetched(true);
            try
            {
                (new Setup()).Warmup();
            }
            catch { }
        }

        [TestMethod]
        public void Warmup()
        {
            // load a single entity to load all meta data in the structures
            using (var adapter = new DataAccessAdapter())
            {
                var departments = new LinqMetaData(adapter).Department.ToList();
            }
        }
    }
}
