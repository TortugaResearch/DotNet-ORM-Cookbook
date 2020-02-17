using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SD.LLBLGen.Pro.DQE.SqlServer;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.Tools.OrmProfiler.Interceptor;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using Injectables;

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
	
// change to TRUE to have ORM Profiler monitoring. Won't work with Connection Sharing.  
#if FALSE			
            // Wrap the factory with a factory from the ORM Profiler so we get real time information about what's going on
            // ORM Profiler is a free tool for LLBLGen Pro subscribers.
            RuntimeConfiguration.ConfigureDQE<SQLServerDQEConfiguration>(c => c.AddDbProviderFactory(InterceptorCore.Initialize("ORM Cookbook",
                                                                                                     typeof(Microsoft.Data.SqlClient.SqlClientFactory)))
                                                                               .SetDefaultCompatibilityLevel(SqlServerCompatibilityLevel.SqlServer2012));
#else
			RuntimeConfiguration.ConfigureDQE<SQLServerDQEConfiguration>(c => c.AddDbProviderFactory(typeof(Microsoft.Data.SqlClient.SqlClientFactory))
#endif
																			   .SetDefaultCompatibilityLevel(SqlServerCompatibilityLevel.SqlServer2012));
            RuntimeConfiguration.Entity.SetMarkSavedEntitiesAsFetched(true);
			// Setup the dependency injection system to auto-inject e.g. auditors when needed. 
			RuntimeConfiguration.SetDependencyInjectionInfo(new List<Assembly>() { typeof(DepartmentAuditor).Assembly}, null);
			
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
