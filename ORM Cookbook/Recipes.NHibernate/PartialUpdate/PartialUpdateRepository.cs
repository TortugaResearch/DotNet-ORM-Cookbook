using NHibernate;
using Recipes.NHibernate.Entities;
using Recipes.PartialUpdate;
using System;

namespace Recipes.NHibernate.PartialUpdate
{
    public class PartialUpdateRepository : IPartialUpdateRepository<EmployeeClassification>
    {
        readonly ISessionFactory m_SessionFactory;

        public PartialUpdateRepository(ISessionFactory sessionFactory)
        {
            m_SessionFactory = sessionFactory;
        }

        public int Create(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var session = m_SessionFactory.OpenSession())
            {
                session.Save(classification);
                session.Flush();
                return classification.EmployeeClassificationKey;
            }
        }

        public EmployeeClassification? GetByKey(int employeeClassificationKey)
        {
            using (var session = m_SessionFactory.OpenStatelessSession())
                return session.Get<EmployeeClassification>(employeeClassificationKey);
        }

        public void UpdateWithObject(EmployeeClassificationNameUpdater updateMessage)
        {
            if (updateMessage == null)
                throw new ArgumentNullException(nameof(updateMessage), $"{nameof(updateMessage)} is null.");

            using (var session = m_SessionFactory.OpenSession())
            {
                var temp = session.Get<EmployeeClassification>(updateMessage.EmployeeClassificationKey);
                if (temp != null)
                {
                    temp.EmployeeClassificationName = updateMessage.EmployeeClassificationName;
                    session.Update(temp);
                    session.Flush();
                }
            }
        }

        public void UpdateWithObject(EmployeeClassificationFlagsUpdater updateMessage)
        {
            if (updateMessage == null)
                throw new ArgumentNullException(nameof(updateMessage), $"{nameof(updateMessage)} is null.");

            using (var session = m_SessionFactory.OpenSession())
            {
                var temp = session.Get<EmployeeClassification>(updateMessage.EmployeeClassificationKey);
                if (temp != null)
                {
                    temp.IsExempt = updateMessage.IsExempt;
                    temp.IsEmployee = updateMessage.IsEmployee;
                    session.Update(temp);
                    session.Flush();
                }
            }
        }

        public void UpdateWithSeparateParameters(int employeeClassificationKey, bool isExempt, bool isEmployee)
        {
            using (var session = m_SessionFactory.OpenSession())
            {
                var temp = session.Get<EmployeeClassification>(employeeClassificationKey);
                if (temp != null)
                {
                    temp.IsExempt = isExempt;
                    temp.IsEmployee = isEmployee;
                    session.Update(temp);
                    session.Flush();
                }
            }
        }
    }
}
