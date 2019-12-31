using BenchmarkDotNet.Attributes;
using Recipes.ServiceStack.PartialUpdate;

namespace Performance
{
    partial class Benchmarks
    {
        [Benchmark]
        public void ServiceStack_PartialUpdateTests_PartialUpdate_IndividualParameters()
        {
            var test = new PartialUpdateTests();
            test.PartialUpdate_IndividualParameters();
        }

        [Benchmark]
        public void ServiceStack_PartialUpdateTests_PartialUpdate_OneRepositoryTwoMessages()
        {
            var test = new PartialUpdateTests();
            test.PartialUpdate_OneRepositoryTwoMessages();
        }

        [Benchmark]
        public void ServiceStack_PartialUpdateTests_PartialUpdate_TwoRepositories()
        {
            var test = new PartialUpdateTests();
            test.PartialUpdate_TwoRepositories();
        }
    }
}
