using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using Recipes.NHibernate.Models;
using Recipes.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.NHibernate.Repositories
{
    public class EmployeeClassificationRepository : IEmployeeClassificationRepository<EmployeeClassification>
    {
        public int Create(EmployeeClassification classification)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.Save(classification);
                session.Flush();
                return classification.EmployeeClassificationKey;
            }
        }

        public void Delete(int employeeClassificationKey)
        {

            using (ISession session = NHibernateHelper.OpenSession())
            {
                var temp = session.Get<EmployeeClassification>(employeeClassificationKey);
                session.Delete(temp);
                session.Flush();
            }
        }

        public void Delete(EmployeeClassification classification)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.Delete(classification);
                session.Flush();
            }
        }

        public EmployeeClassification FindByName(string employeeClassificationName)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session
                    .CreateCriteria(typeof(EmployeeClassification))
                    .Add(Restrictions.Eq("EmployeeClassificationName", employeeClassificationName))
                    .List<EmployeeClassification>()
                    .SingleOrDefault();
            }
        }

        public IList<EmployeeClassification> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session
                    .CreateCriteria(typeof(EmployeeClassification))
                    .List<EmployeeClassification>();
            }
        }

        public EmployeeClassification GetByKey(int employeeClassificationKey)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.Get<EmployeeClassification>(employeeClassificationKey);
        }

        public void Update(EmployeeClassification classification)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.Update(classification);
                session.Flush();
            }
        }
    }
}
