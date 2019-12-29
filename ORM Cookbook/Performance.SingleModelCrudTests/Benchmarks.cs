namespace Performance
{
    public partial class Benchmarks
    {
        public Benchmarks()
        {
            Recipes.Chain.Setup.AssemblyInit(null);
            Recipes.EntityFrameworkCore.Setup.AssemblyInit(null);
        }
    }
}
