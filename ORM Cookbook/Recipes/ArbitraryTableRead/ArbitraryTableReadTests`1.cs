using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Recipes.ArbitraryTableRead
{
    /// <summary>
    /// This scenario reads from stored procedures
    /// </summary>
    [TestCategory("ArbitraryTableRead")]
    public abstract class ArbitraryTableReadTests<T>
    {
        [TestMethod]
        public void ListContentsOfTable()
        {
            const int ExpectedColumnCount = 14;
            const int MinimumRowCount = 5;

            var repository = GetScenario();
            var result = repository.GetAll("HR", "Division");

            Assert.IsNotNull(result);

            switch (result)
            {
                case DataTable dt:
                    Assert.IsTrue(dt.Rows.Count >= MinimumRowCount, "Row count");
                    Assert.AreEqual(ExpectedColumnCount, dt.Columns.Count, "Column count");
                    break;

                case IList list:
                    Assert.IsTrue(list.Count >= MinimumRowCount, "Row count");

                    switch (list[0])
                    {
                        case IDictionary<string, object?> row:
                            Assert.AreEqual(ExpectedColumnCount, row.Count, "Column count");
                            break;

                        case IReadOnlyDictionary<string, object?> row2:
                            Assert.AreEqual(ExpectedColumnCount, row2.Count, "Column count");
                            break;

                        default:
                            Assert.Inconclusive("Unknown row type. Please update test.");
                            break;
                    }

                    break;

                default:
                    Assert.Inconclusive("Unknown result type. Please update test.");
                    break;
            }
        }

        protected abstract IArbitraryTableReadScenario<T> GetScenario();
    }
}
