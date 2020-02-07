using Recipes.SingleColumn;
using System;
using System.Collections.Generic;
using Tortuga.Chain;

namespace Recipes.Chain.SingleColumn
{
    public class SingleColumnScenario : ISingleColumnScenario
    {
        const string TableName = "HR.Division";
        readonly SqlServerDataSource m_DataSource;

        public SingleColumnScenario(SqlServerDataSource dataSource)
        {
            m_DataSource = dataSource;
        }

        public List<int> GetDivisionKeys(int maxDivisionKey)
        {
            return m_DataSource.From(TableName, "DivisionKey <= @MaxDivisionKey", new { maxDivisionKey })
                .ToInt32List("DivisionKey").Execute();
        }

        public List<string> GetDivisionNames(int maxDivisionKey)
        {
            return m_DataSource.From(TableName, "DivisionKey <= @MaxDivisionKey", new { maxDivisionKey })
                .ToStringList("DivisionName").Execute();
        }

        public List<DateTimeOffset?> GetLastReviewCycles(int maxDivisionKey)
        {
            return m_DataSource.From(TableName, "DivisionKey <= @MaxDivisionKey", new { maxDivisionKey })
                .ToDateTimeOffsetOrNullList("LastReviewCycle").Execute();
        }

        public List<int?> GetMaxEmployees(int maxDivisionKey)
        {
            return m_DataSource.From(TableName, "DivisionKey <= @MaxDivisionKey", new { maxDivisionKey })
                .ToInt32OrNullList("MaxEmployees").Execute();
        }

        public List<DateTime> GetModifiedDates(int maxDivisionKey)
        {
            return m_DataSource.From(TableName, "DivisionKey <= @MaxDivisionKey", new { maxDivisionKey })
                .ToDateTimeList("ModifiedDate").Execute();
        }

        public List<decimal?> GetSalaryBudgets(int maxDivisionKey)
        {
            return m_DataSource.From(TableName, "DivisionKey <= @MaxDivisionKey", new { maxDivisionKey })
                .ToDecimalOrNullList("SalaryBudget").Execute();
        }

        public List<TimeSpan?> GetStartTimes(int maxDivisionKey)
        {
            return m_DataSource.From(TableName, "DivisionKey <= @MaxDivisionKey", new { maxDivisionKey })
                   .ToTimeSpanOrNullList("StartTime").Execute();
        }
    }
}
