using BenchmarkDotNet.Attributes;
using Recipes.EntityFrameworkCore.SingleModelCrud;
using Recipes.EntityFrameworkCore.SingleModelCrudAsync;
using System.Threading.Tasks;

namespace Performance
{
    partial class Benchmarks
    {
        #region SingleModelCrudTests

        [Benchmark]
        public void EFCore_SingleModelCrudTests_CreateAndReadBack()
        {
            var test = new SingleModelCrudTests();
            test.CreateAndReadBack();
        }

        /// <summary>
        /// Create and delete a row.
        /// </summary>
        [Benchmark]
        public void EFCore_SingleModelCrudTests_CreateAndDeleteByModel()
        {
            var test = new SingleModelCrudTests();
            test.CreateAndDeleteByModel();
        }

        /// <summary>
        /// Create and delete a row.
        /// </summary>
        [Benchmark]
        public void EFCore_SingleModelCrudTests_CreateAndDeleteByKey()
        {
            var test = new SingleModelCrudTests();
            test.CreateAndDeleteByKey();
        }

        /// <summary>
        /// Get all rows from a table.
        /// </summary>
        [Benchmark]
        public void EFCore_SingleModelCrudTests_GetAll()
        {
            var test = new SingleModelCrudTests();
            test.GetAll();
        }

        /// <summary>
        /// Get a row using a primary key.
        /// </summary>
        [Benchmark]
        public void EFCore_SingleModelCrudTests_GetByKey()
        {
            var test = new SingleModelCrudTests();
            test.GetByKey();
        }

        /// <summary>
        /// Create and update a row.
        /// </summary>
        [Benchmark]
        public void EFCore_SingleModelCrudTests_CreateAndUpdate()
        {
            var test = new SingleModelCrudTests();
            test.CreateAndUpdate();
        }

        #endregion SingleModelCrudTests

        #region SingleModelCrudTests2

        [Benchmark]
        public void EFCore_SingleModelCrudTests2_CreateAndReadBack()
        {
            var test = new SingleModelCrudTests2();
            test.CreateAndReadBack();
        }

        /// <summary>
        /// Create and delete a row.
        /// </summary>
        [Benchmark]
        public void EFCore_SingleModelCrudTests2_CreateAndDeleteByModel()
        {
            var test = new SingleModelCrudTests2();
            test.CreateAndDeleteByModel();
        }

        /// <summary>
        /// Create and delete a row.
        /// </summary>
        [Benchmark]
        public void EFCore_SingleModelCrudTests2_CreateAndDeleteByKey()
        {
            var test = new SingleModelCrudTests2();
            test.CreateAndDeleteByKey();
        }

        /// <summary>
        /// Get all rows from a table.
        /// </summary>
        [Benchmark]
        public void EFCore_SingleModelCrudTests2_GetAll()
        {
            var test = new SingleModelCrudTests2();
            test.GetAll();
        }

        /// <summary>
        /// Get a row using a primary key.
        /// </summary>
        [Benchmark]
        public void EFCore_SingleModelCrudTests2_GetByKey()
        {
            var test = new SingleModelCrudTests2();
            test.GetByKey();
        }

        /// <summary>
        /// Create and update a row.
        /// </summary>
        [Benchmark]
        public void EFCore_SingleModelCrudTests2_CreateAndUpdate()
        {
            var test = new SingleModelCrudTests2();
            test.CreateAndUpdate();
        }

        #endregion SingleModelCrudTests2

        #region SingleModelCrudAsyncTests

        [Benchmark]
        public Task EFCore_SingleModelCrudAsyncTests_CreateAndReadBack()
        {
            var test = new SingleModelCrudAsyncTests();
            return test.CreateAndReadBackAsync();
        }

        /// <summary>
        /// Create and delete a row.
        /// </summary>
        [Benchmark]
        public Task EFCore_SingleModelCrudAsyncTests_CreateAndDeleteByModel()
        {
            var test = new SingleModelCrudAsyncTests();
            return test.CreateAndDeleteByModelAsync();
        }

        /// <summary>
        /// Create and delete a row.
        /// </summary>
        [Benchmark]
        public Task EFCore_SingleModelCrudAsyncTests_CreateAndDeleteByKey()
        {
            var test = new SingleModelCrudAsyncTests();
            return test.CreateAndDeleteByKeyAsync();
        }

        /// <summary>
        /// Get all rows from a table.
        /// </summary>
        [Benchmark]
        public Task EFCore_SingleModelCrudAsyncTests_GetAll()
        {
            var test = new SingleModelCrudAsyncTests();
            return test.GetAllAsync();
        }

        /// <summary>
        /// Get a row using a primary key.
        /// </summary>
        [Benchmark]
        public Task EFCore_SingleModelCrudAsyncTests_GetByKey()
        {
            var test = new SingleModelCrudAsyncTests();
            return test.GetByKeyAsync();
        }

        /// <summary>
        /// Create and update a row.
        /// </summary>
        [Benchmark]
        public Task EFCore_SingleModelCrudAsyncTests_CreateAndUpdate()
        {
            var test = new SingleModelCrudAsyncTests();
            return test.CreateAndUpdateAsync();
        }

        #endregion SingleModelCrudAsyncTests
    }
}
