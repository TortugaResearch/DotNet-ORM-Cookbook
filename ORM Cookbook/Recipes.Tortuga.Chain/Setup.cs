using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Tortuga.Chain;

namespace Recipes.Chain
{
    [TestClass]
    public class Setup
    {
#nullable disable
        internal static SqlServerDataSource PrimaryDataSource { get; private set; }
#nullable enable

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
        }

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory).AddJsonFile("appsettings.json").Build();
            var con = configuration.GetSection("ConnectionStrings").GetChildren().Single();
            PrimaryDataSource = new SqlServerDataSource(con.Key, con.Value);
        }

        [TestMethod]
        public void Warmup()
        {
            //Preload all of the database metadata to warmup the data source
            PrimaryDataSource.DatabaseMetadata.Preload();
        }
    }
}
