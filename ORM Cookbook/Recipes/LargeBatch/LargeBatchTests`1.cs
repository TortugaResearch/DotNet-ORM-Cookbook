using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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

        [TestMethod]
        public void InsertBatch_100_000()
        {
            const int RowCount = 100_000;
            var repostory = GetScenario();

            var batchKey = Guid.NewGuid().ToString();
            var originals = BuildEmployees(RowCount, batchKey);
            repostory.InsertLargeBatch(originals);

            var actual = repostory.CountByLastName(batchKey);
            Assert.AreEqual(RowCount, actual, "Incorrect number of rows created");
        }

        protected abstract ILargeBatchScenario<TEmployeeSimple> GetScenario();

        static IList<TEmployeeSimple> BuildEmployees(int count, string batchKey)
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