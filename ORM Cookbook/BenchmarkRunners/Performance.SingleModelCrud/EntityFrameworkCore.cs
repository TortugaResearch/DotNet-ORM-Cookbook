using BenchmarkDotNet.Attributes;
using Recipes.EntityFrameworkCore.SingleModelCrud;
using Recipes.EntityFrameworkCore.SingleModelCrudAsync;
using System.Threading.Tasks;

namespace Performance
{
    partial class Benchmarks
    {
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
    }
}
