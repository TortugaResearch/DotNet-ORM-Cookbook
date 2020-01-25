using NHibernate;
using Recipes.NHibernate.Entities;
using Recipes.Upsert;
using System;
using System.Linq;

namespace Recipes.NHibernate.Upsert
{
    public class UpsertScenario : IUpsertScenario<Division>
    {
        readonly ISessionFactory m_SessionFactory;

        public UpsertScenario(ISessionFactory sessionFactory)
        {
            m_SessionFactory = sessionFactory;
        }

        public Division GetByKey(int divisionKey)
        {
            using (var session = m_SessionFactory.OpenSession())
                return session.Get<Division>(divisionKey);
        }

        public int UpsertByName(Division division)
        {
            if (division == null)
                throw new ArgumentNullException(nameof(division), $"{nameof(division)} is null.");

            //update audit column
            division.CreatedDate = DateTime.UtcNow;
            division.ModifiedDate = DateTime.UtcNow;

            using (var session = m_SessionFactory.OpenSession())
            {
                //check to see if the row already exists
                var actual = session.Query<Division>().Where(x => x.DivisionName == division.DivisionName).SingleOrDefault();
                if (actual == null) //Insert
                {
                    session.Save(division);
                    session.Flush();
                    return division.DivisionKey;
                }
                else //Update
                {
                    //Copy manually so we don't overwrite CreatedBy/CreatedDate
                    actual.DivisionId = division.DivisionId;
                    actual.DivisionName = division.DivisionName;
                    actual.FloorSpaceBudget = division.FloorSpaceBudget;
                    actual.FteBudget = division.FteBudget;
                    actual.LastReviewCycle = division.LastReviewCycle;
                    actual.MaxEmployees = division.MaxEmployees;
                    actual.ModifiedByEmployeeKey = division.ModifiedByEmployeeKey;
                    actual.ModifiedDate = division.ModifiedDate;
                    actual.SalaryBudget = division.SalaryBudget;
                    actual.StartTime = division.StartTime;
                    actual.SuppliesBudget = division.SuppliesBudget;
                    session.Flush();
                    return actual.DivisionKey;
                }
            }
        }

        public int UpsertByPrimaryKey(Division division)
        {
            if (division == null)
                throw new ArgumentNullException(nameof(division), $"{nameof(division)} is null.");

            //update audit column
            division.CreatedDate = DateTime.UtcNow;
            division.ModifiedDate = DateTime.UtcNow;

            using (var session = m_SessionFactory.OpenSession())
            {
                //If DivisionKey is zero, we know this is a new row
                if (division.DivisionKey == 0) //Insert
                {
                    session.Save(division);
                    session.Flush();
                    return division.DivisionKey;
                }
                else //Update
                {
                    //This wouldn't be necessary if we were replacing all columns.
                    var actual = session.Get<Division>(division.DivisionKey);

                    //Copy manually so we don't overwrite CreatedBy/CreatedDate
                    actual.DivisionId = division.DivisionId;
                    actual.DivisionName = division.DivisionName;
                    actual.FloorSpaceBudget = division.FloorSpaceBudget;
                    actual.FteBudget = division.FteBudget;
                    actual.LastReviewCycle = division.LastReviewCycle;
                    actual.MaxEmployees = division.MaxEmployees;
                    actual.ModifiedByEmployeeKey = division.ModifiedByEmployeeKey;
                    actual.ModifiedDate = division.ModifiedDate;
                    actual.SalaryBudget = division.SalaryBudget;
                    actual.StartTime = division.StartTime;
                    actual.SuppliesBudget = division.SuppliesBudget;
                    session.Flush();
                    return actual.DivisionKey;
                }
            }
        }
    }
}
