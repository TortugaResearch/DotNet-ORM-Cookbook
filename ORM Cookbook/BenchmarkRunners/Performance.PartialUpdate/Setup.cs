using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Performance
{
    [SimpleJob(launchCount: 1, warmupCount: 3, targetCount: 5, invocationCount: 10)]
    public partial class Benchmarks
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmarks>();
        }

        public Benchmarks()
        {
            Recipes.Chain.Setup.AssemblyInit(null);
            Recipes.EntityFrameworkCore.Setup.AssemblyInit(null);
            Recipes.Dapper.Setup.AssemblyInit(null);
            Recipes.Ado.Setup.AssemblyInit(null);
            Recipes.RepoDb.Setup.AssemblyInit(null);
            Recipes.NHibernate.Setup.AssemblyInit(null);
            Recipes.ServiceStack.Setup.AssemblyInit(null);
			Recipes.LLBLGenPro.Setup.AssemblyInit(null);
        }
    }
}
