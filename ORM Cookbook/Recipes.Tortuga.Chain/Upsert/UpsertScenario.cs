using Recipes.Chain.Models;
using Recipes.Upsert;
using System;
using Tortuga.Chain;
using Tortuga.Chain.AuditRules;

namespace Recipes.Chain.Upsert
{
    public class UpsertScenario : IUpsertScenario<Division>
    {
        readonly SqlServerDataSource m_DataSource;

        public UpsertScenario(SqlServerDataSource dataSource)
        {
            if (dataSource == null)
                throw new ArgumentNullException(nameof(dataSource), $"{nameof(dataSource)} is null.");

            //Auto-populate the ModifiedDate column
            m_DataSource = dataSource.WithRules(
                new DateTimeRule("ModifiedDate", DateTimeKind.Utc, OperationTypes.Update)
                );
        }

        public Division GetByKey(int divisionKey)
        {
            return m_DataSource.GetByKey<Division>(divisionKey).ToObject().Execute()!;
        }

        public int UpsertByName(Division division)
        {
            //WithKeys indicates that we're matching on something other than the primary key
            return m_DataSource.Upsert(division).WithKeys("DivisionName").ToInt32().Execute();
        }

        public int UpsertByPrimaryKey(Division division)
        {
            return m_DataSource.Upsert(division).ToInt32().Execute();
        }
    }
}
