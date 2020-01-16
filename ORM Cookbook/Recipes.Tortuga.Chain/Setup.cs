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
#nullable disable
        internal static SqlServerDataSource PrimaryDataSource { get; private set; }
#nullable enable

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
            PrimaryDataSource = new SqlServerDataSource(sqlServerConnectionString);

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
            PrimaryDataSource.From("HR.EmployeeClassification", "1=0").Compile().ToObject<EmployeeClassification>(RowOptions.AllowEmptyResults).Execute();
        }
    }
}
