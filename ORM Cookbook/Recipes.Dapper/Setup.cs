using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;

[assembly: DoNotParallelize]

namespace Recipes.Dapper;

[TestClass]
public class Setup
{
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
        PostgreSqlConnectionString = configuration.GetSection("ConnectionStrings")["PostgreSqlTestDatabase"]!;

        try
        {
            (new Setup()).Warmup();
        }
        catch { }
    }

    [TestMethod]
    public void Warmup()
    {
        //Make sure we can connect to the database. This will also pool a connection for future use.
        using (var con = new SqlConnection(SqlServerConnectionString))
        using (var cmd = new SqlCommand("SELECT 1", con))
        {
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
}