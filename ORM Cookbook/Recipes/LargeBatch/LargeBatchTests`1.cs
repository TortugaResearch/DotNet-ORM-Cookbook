using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Recipes.LargeBatch
{
    /// <summary>
    /// This scenario works with collections of objects.
    /// </summary>
    [TestCategory("LargeBatch")]
    public abstract class LargeBatchTests<TEmployeeSimple> : TestBase
       where TEmployeeSimple : class, IEmployeeSimple, new()
    {
        [TestMethod]
        [DataRow(50)]
        [DataRow(100)]
        [DataRow(250)]
        [DataRow(500)]
        [DataRow(1000)]
        public void InsertBatch_1000_Varying(int batchSize)
        {
            const int RowCount = 1000;

            var repostory = GetScenario();
            if (batchSize > repostory.MaximumBatchSize)
                Assert.Inconclusive($"BatchSize of {batchSize} is not supported by this ORM with this table.");

            var batchKey = Guid.NewGuid().ToString();
            var originals = BuildEmployees(RowCount, batchKey);
            var sw = Stopwatch.StartNew();
            repostory.InsertLargeBatch(originals, batchSize);
            sw.Stop();
            Debug.WriteLine("Run time " + sw.Elapsed.TotalSeconds.ToString("0.00") + " sec.");

            var actual = repostory.CountByLastName(batchKey);
            Assert.AreEqual(RowCount, actual, "Incorrect number of rows created");
        }

        [TestMethod]
        public void InsertBatch_1000()
        {
            const int RowCount = 1000;
            var repostory = GetScenario();

            var batchKey = Guid.NewGuid().ToString();
            var originals = BuildEmployees(RowCount, batchKey);
            repostory.InsertLargeBatch(originals);

            var actual = repostory.CountByLastName(batchKey);
            Assert.AreEqual(RowCount, actual, "Incorrect number of rows created");
        }

        [TestMethod]
        public void InsertBatch_10_000()
        {
            const int RowCount = 10_000;
            var repostory = GetScenario();

            var batchKey = Guid.NewGuid().ToString();
            var originals = BuildEmployees(RowCount, batchKey);

            repostory.InsertLargeBatch(originals);

            var actual = repostory.CountByLastName(batchKey);
            Assert.AreEqual(RowCount, actual, "Incorrect number of rows created");
        }

        protected abstract ILargeBatchScenario<TEmployeeSimple> GetScenario();

        static protected IList<TEmployeeSimple> BuildEmployees(int count, string batchKey)
        {
            var result = new List<TEmployeeSimple>();
            for (var i = 0; i < count; i++)
            {
                result.Add(new TEmployeeSimple
                {
                    FirstName = "Test " + (i % 3),
                    MiddleName = "A" + i,
                    LastName = batchKey,
                    EmployeeClassificationKey = (i % 7) + 1
                });
            }
            return result;
        }
    }
}
