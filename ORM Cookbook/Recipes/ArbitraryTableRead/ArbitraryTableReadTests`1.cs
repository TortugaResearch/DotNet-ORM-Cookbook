using System.Collections;
using System.Data;

namespace Recipes.ArbitraryTableRead;

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
                Assert.IsGreaterThanOrEqualTo(MinimumRowCount, dt.Rows.Count, "Row count");
                Assert.HasCount(ExpectedColumnCount, dt.Columns, "Column count");
                break;

            case IList list:
                Assert.IsGreaterThanOrEqualTo(MinimumRowCount, list.Count, "Row count");

                switch (list[0])
                {
                    case IDictionary<string, object?> row:
                        Assert.HasCount(ExpectedColumnCount, row, "Column count");
                        break;

                    case IReadOnlyDictionary<string, object?> row2:
                        Assert.HasCount(ExpectedColumnCount, row2, "Column count");
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