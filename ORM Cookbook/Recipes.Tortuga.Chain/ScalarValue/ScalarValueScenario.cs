using Recipes.ScalarValue;
using Tortuga.Chain;

namespace Recipes.Chain.ScalarValue;

public class ScalarValueScenario : IScalarValueScenario
{
    const string TableName = "HR.Division";
    readonly SqlServerDataSource m_DataSource;

    public ScalarValueScenario(SqlServerDataSource dataSource)
    {
        m_DataSource = dataSource;
    }

    public int? GetDivisionKey(string divisionName)
    {
        return m_DataSource.From(TableName, new { divisionName }).ToInt32OrNull("DivisionKey").Execute();
    }

    public string GetDivisionName(int divisionKey)
    {
        return m_DataSource.From(TableName, new { divisionKey }).ToString("DivisionName").Execute();
    }

    public string? GetDivisionNameOrNull(int divisionKey)
    {
        return m_DataSource.From(TableName, new { divisionKey }).ToStringOrNull("DivisionName").Execute();
    }

    public DateTimeOffset? GetLastReviewCycle(int divisionKey)
    {
        return m_DataSource.From(TableName, new { divisionKey }).ToDateTimeOffsetOrNull("LastReviewCycle").Execute();
    }

    public int? GetMaxEmployees(int divisionKey)
    {
        return m_DataSource.From(TableName, new { divisionKey }).ToInt32OrNull("MaxEmployees").Execute();
    }

    public DateTime GetModifiedDate(int divisionKey)
    {
        return m_DataSource.From(TableName, new { divisionKey }).ToDateTime("ModifiedDate").Execute();
    }

    public decimal? GetSalaryBudget(int divisionKey)
    {
        return m_DataSource.From(TableName, new { divisionKey }).ToDecimalOrNull("SalaryBudget").Execute();
    }

    public TimeSpan? GetStartTime(int divisionKey)
    {
        return m_DataSource.From(TableName, new { divisionKey }).ToTimeSpanOrNull("StartTime").Execute();
    }
}