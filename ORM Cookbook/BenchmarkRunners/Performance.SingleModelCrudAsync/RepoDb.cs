using BenchmarkDotNet.Attributes;
using Recipes.RepoDb.SingleModelCrudAsync;
using System.Threading.Tasks;

namespace Performance
{
    partial class Benchmarks
    {
        [Benchmark]
        public Task RepoDb_SingleModelCrudAsyncTests_CreateAndReadBack()
        {
            var test = new SingleModelCrudAsyncTests();
            return test.CreateAndReadBackAsync();
        }

        /// <summary>
        /// Create and delete a row.
        /// </summary>
        [Benchmark]
        public Task RepoDb_SingleModelCrudAsyncTests_CreateAndDeleteByModel()
        {
            var test = new SingleModelCrudAsyncTests();
            return test.CreateAndDeleteByModelAsync();
        }

        /// <summary>
        /// Create and delete a row.
        /// </summary>
        [Benchmark]
        public Task RepoDb_SingleModelCrudAsyncTests_CreateAndDeleteByKey()
        {
            var test = new SingleModelCrudAsyncTests();
            return test.CreateAndDeleteByKeyAsync();
        }

        /// <summary>
        /// Get all rows from a table.
        /// </summary>
        [Benchmark]
        public Task RepoDb_SingleModelCrudAsyncTests_GetAll()
        {
            var test = new SingleModelCrudAsyncTests();
            return test.GetAllAsync();
        }

        /// <summary>
        /// Get a row using a primary key.
        /// </summary>
        [Benchmark]
        public Task RepoDb_SingleModelCrudAsyncTests_GetByKey()
        {
            var test = new SingleModelCrudAsyncTests();
            return test.GetByKeyAsync();
        }

        /// <summary>
        /// Create and update a row.
        /// </summary>
        [Benchmark]
        public Task RepoDb_SingleModelCrudAsyncTests_CreateAndUpdate()
        {
            var test = new SingleModelCrudAsyncTests();
            return test.CreateAndUpdateAsync();
        }
    }
}
