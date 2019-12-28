using BenchmarkDotNet.Attributes;
using Recipes.EntityFrameworkCore;
using Recipes.EntityFrameworkCore.SingleModelCrud;

namespace Performance.EntityFrameworkCore
{
    public class Benchmarks
    {
        public Benchmarks()
        {
            Setup.AssemblyInit(null);
        }

        #region SingleModelCrudTests

        [Benchmark]
        public void SingleModelCrudTests_CreateAndReadBack()
        {
            var test = new SingleModelCrudTests();
            test.CreateAndReadBack();
        }

        /// <summary>
        /// Create and delete a row.
        /// </summary>
        [Benchmark]
        public void SingleModelCrudTests_CreateAndDeleteByModel()
        {
            var test = new SingleModelCrudTests();
            test.CreateAndDeleteByModel();
        }

        /// <summary>
        /// Create and delete a row.
        /// </summary>
        [Benchmark]
        public void SingleModelCrudTests_CreateAndDeleteByKey()
        {
            var test = new SingleModelCrudTests();
            test.CreateAndDeleteByKey();
        }

        /// <summary>
        /// Get all rows from a table.
        /// </summary>
        [Benchmark]
        public void SingleModelCrudTests_GetAll()
        {
            var test = new SingleModelCrudTests();
            test.GetAll();
        }

        /// <summary>
        /// Get a row using a primary key.
        /// </summary>
        [Benchmark]
        public void SingleModelCrudTests_GetByKey()
        {
            var test = new SingleModelCrudTests();
            test.GetByKey();
        }

        /// <summary>
        /// Create and update a row.
        /// </summary>
        [Benchmark]
        public void SingleModelCrudTests_CreateAndUpdate()
        {
            var test = new SingleModelCrudTests();
            test.CreateAndUpdate();
        }

        #endregion SingleModelCrudTests

        #region SingleModelCrudTests2

        [Benchmark]
        public void SingleModelCrudTests2_CreateAndReadBack()
        {
            var test = new SingleModelCrudTests2();
            test.CreateAndReadBack();
        }

        /// <summary>
        /// Create and delete a row.
        /// </summary>
        [Benchmark]
        public void SingleModelCrudTests2_CreateAndDeleteByModel()
        {
            var test = new SingleModelCrudTests2();
            test.CreateAndDeleteByModel();
        }

        /// <summary>
        /// Create and delete a row.
        /// </summary>
        [Benchmark]
        public void SingleModelCrudTests2_CreateAndDeleteByKey()
        {
            var test = new SingleModelCrudTests2();
            test.CreateAndDeleteByKey();
        }

        /// <summary>
        /// Get all rows from a table.
        /// </summary>
        [Benchmark]
        public void SingleModelCrudTests2_GetAll()
        {
            var test = new SingleModelCrudTests2();
            test.GetAll();
        }

        /// <summary>
        /// Get a row using a primary key.
        /// </summary>
        [Benchmark]
        public void SingleModelCrudTests2_GetByKey()
        {
            var test = new SingleModelCrudTests2();
            test.GetByKey();
        }

        /// <summary>
        /// Create and update a row.
        /// </summary>
        [Benchmark]
        public void SingleModelCrudTests2_CreateAndUpdate()
        {
            var test = new SingleModelCrudTests2();
            test.CreateAndUpdate();
        }

        #endregion SingleModelCrudTests2
    }
}
