using BenchmarkDotNet.Attributes;
using Recipes.NHibernate.PartialUpdate;

namespace Performance
{
    partial class Benchmarks
    {
        [Benchmark]
        public void NHibernate_PartialUpdateTests_PartialUpdate_IndividualParameters()
        {
            var test = new PartialUpdateTests();
            test.PartialUpdate_IndividualParameters();
        }

        [Benchmark]
        public void NHibernate_PartialUpdateTests_PartialUpdate_OneScenarioTwoMessages()
        {
            var test = new PartialUpdateTests();
            test.PartialUpdate_OneScenarioTwoMessages();
        }

        [Benchmark]
        public void NHibernate_PartialUpdateTests_PartialUpdate_TwoRepositories()
        {
            var test = new PartialUpdateTests();
            test.PartialUpdate_TwoRepositories();
        }
    }
}
