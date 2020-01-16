using BenchmarkDotNet.Attributes;
using Recipes.Ado.PartialUpdate;

namespace Performance
{
    partial class Benchmarks
    {
        [Benchmark]
        public void Ado_PartialUpdateTests_PartialUpdate_IndividualParameters()
        {
            var test = new PartialUpdateTests();
            test.PartialUpdate_IndividualParameters();
        }

        [Benchmark]
        public void Ado_PartialUpdateTests_PartialUpdate_OneScenarioTwoMessages()
        {
            var test = new PartialUpdateTests();
            test.PartialUpdate_OneScenarioTwoMessages();
        }

        [Benchmark]
        public void Ado_PartialUpdateTests_PartialUpdate_TwoRepositories()
        {
            var test = new PartialUpdateTests();
            test.PartialUpdate_TwoRepositories();
        }
    }
}
