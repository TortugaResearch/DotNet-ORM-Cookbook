using Recipes.Chain.Models;
using Recipes.LargeBatch;
using System;
using System.Collections.Generic;
using Tortuga.Chain;

namespace Recipes.Chain.LargeBatch
{
    public class LargeBatchScenario : ILargeBatchScenario<EmployeeSimple>
    {
        readonly SqlServerDataSource m_DataSource;

        public LargeBatchScenario(SqlServerDataSource dataSource)
        {
            m_DataSource = dataSource;
        }

        public int CountByLastName(string lastName)
        {
            return (int)m_DataSource.From<EmployeeSimple>(new { lastName }).AsCount().Execute();
        }

        public int MaximumBatchSize => 2100 / 7;

        public void InsertLargeBatch(IList<EmployeeSimple> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            using (var trans = m_DataSource.BeginTransaction())
            {
                trans.InsertMultipleBatch((IReadOnlyList<EmployeeSimple>)employees).Execute();
                trans.Commit();
            }
        }

        public void InsertLargeBatch(IList<EmployeeSimple> employees, int batchSize)
        {
            using (var trans = m_DataSource.BeginTransaction())
            {
                //This is essentially what InsertMultipleBatch does
                foreach (var batch in employees.BatchAsLists(batchSize))
                    trans.InsertBatch((IReadOnlyList<EmployeeSimple>)batch).Execute();

                trans.Commit();
            }
        }
    }
}
