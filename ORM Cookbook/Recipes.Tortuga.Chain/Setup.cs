using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Chain.Models;
using System;
using System.Diagnostics.CodeAnalysis;
using Tortuga.Chain;

namespace Recipes.Chain
{
    [TestClass]
    public class Setup
    {
        internal static SqlServerDataSource PrimaryDataSource { get; private set; } = null!;
        internal static string SqlServerConnectionString { get; private set; } = null!;

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
        }

        [AssemblyInitialize]
        [SuppressMessage("Usage", "CA1801")]
        public static void AssemblyInit(TestContext context)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json").Build();

            SqlServerConnectionString = configuration.GetSection("ConnectionStrings")["SqlServerTestDatabase"];
            PrimaryDataSource = new SqlServerDataSource(SqlServerConnectionString);

            try
            {
                (new Setup()).Warmup();
            }
            catch { }
        }

        [TestMethod]
        public void Warmup()
        {
            //Preload all of the database metadata to warmup the data source
            PrimaryDataSource.DatabaseMetadata.Preload();
            PrimaryDataSource.From("HR.EmployeeClassification", "1=0").Compile()
                .ToObjectOrNull<EmployeeClassification>().Execute();
        }
    }
}
