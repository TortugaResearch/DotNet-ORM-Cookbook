using Microsoft.Extensions.Configuration;
using Recipes.Chain.Models;
using System.Diagnostics.CodeAnalysis;
using Tortuga.Chain;

[assembly: DoNotParallelize]

namespace Recipes.Chain;

[TestClass]
public class Setup
{
    internal static SqlServerDataSource PrimaryDataSource { get; private set; } = null!;
    internal static PostgreSqlDataSource PostgreSqlDataSource { get; private set; } = null!;
    internal static string SqlServerConnectionString { get; private set; } = null!;
    internal static string PostgreSqlConnectionString { get; private set; } = null!;

    [AssemblyCleanup]
    public static void AssemblyCleanup()
    {
    }

    [AssemblyInitialize]
    [SuppressMessage("Usage", "CA1801")]
    public static void AssemblyInit(TestContext context)
    {
        var configuration = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory).AddJsonFile("appsettings.json").Build();
        SqlServerConnectionString = configuration.GetSection("ConnectionStrings")["SqlServerTestDatabase"]!;
        PrimaryDataSource = new SqlServerDataSource(SqlServerConnectionString);

        PostgreSqlConnectionString = configuration.GetSection("ConnectionStrings")["PostgreSqlTestDatabase"]!;
        PostgreSqlDataSource = new PostgreSqlDataSource(PostgreSqlConnectionString);

        try
        {
            (new Setup()).Warmup_SqlServer();
            (new Setup()).Warmup_PostgreSql();
        }
        catch { }
    }

    [TestMethod]
    public void Warmup_SqlServer()
    {
        //Preload all of the database metadata to warmup the data source
        PrimaryDataSource.DatabaseMetadata.Preload();
        PrimaryDataSource.From("HR.EmployeeClassification", "1=0").Compile().ToObjectOrNull<EmployeeClassification>().Execute();
    }

    [TestMethod]
    public void Warmup_PostgreSql()
    {
        //Preload all of the database metadata to warmup the data source
        PostgreSqlDataSource.DatabaseMetadata.Preload();
        PostgreSqlDataSource.From("HR.EmployeeClassification", "1=0").Compile().ToObjectOrNull<EmployeeClassification>().Execute();
    }
}