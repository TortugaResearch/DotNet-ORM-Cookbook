namespace Performance
{
    public partial class Benchmarks
    {
        public Benchmarks()
        {
            Recipes.Chain.Setup.AssemblyInit(null);
            Recipes.EntityFrameworkCore.Setup.AssemblyInit(null);
            Recipes.Dapper.Setup.AssemblyInit(null);
            Recipes.Ado.Setup.AssemblyInit(null);
            Recipes.RepoDb.Setup.AssemblyInit(null);
        }
    }
}
