using Recipes.Chain.Models;
using Recipes.RowCount;
using System;
using System.Collections.Generic;
using Tortuga.Chain;

namespace Recipes.Chain.RowCount
{
    public class RowCountScenario : IRowCountScenario<EmployeeSimple>
    {
        readonly SqlServerDataSource m_DataSource;

        public RowCountScenario(SqlServerDataSource dataSource)
        {
            m_DataSource = dataSource;
        }

        public int EmployeeCount(string lastName)
        {
            return (int)m_DataSource.From<EmployeeSimple>(new { lastName }).AsCount().Execute();
        }

        public int EmployeeCount()
        {
            return (int)m_DataSource.From<EmployeeSimple>().AsCount().Execute();
        }

        public void InsertBatch(IList<EmployeeSimple> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            m_DataSource.InsertBatch((IReadOnlyList<EmployeeSimple>)employees).Execute();
        }
    }
}
