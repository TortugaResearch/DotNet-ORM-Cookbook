using NHibernate;
using Recipes.NHibernate.Entities;
using Recipes.PopulateDataTable;
using System;
using System.Data;
using System.Linq;

namespace Recipes.NHibernate.PopulateDataTable
{
    public class PopulateDataTableScenario : IPopulateDataTableScenario
    {
        readonly ISessionFactory m_SessionFactory;

        public PopulateDataTableScenario(ISessionFactory sessionFactory)
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

        public void DeleteByKey(int employeeClassificationKey)
        {
            using (var session = m_SessionFactory.OpenSession())
            {
                session.Delete(new EmployeeClassification() { EmployeeClassificationKey = employeeClassificationKey });
                session.Flush();
            }
        }

        public DataTable FindByFlags(bool isExempt, bool isEmployee)
        {
            //Note that this uses ":ParameterName" instead of SQL Server's normal "@ParameterName".
            var sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee FROM HR.EmployeeClassification ec WHERE ec.IsExempt = :IsExempt AND ec.IsEmployee = :IsEmployee;";

            using (var session = m_SessionFactory.OpenStatelessSession())
            {
                var sqlQuery = session.CreateSQLQuery(sql);
                sqlQuery.SetParameter("IsExempt", isExempt);
                sqlQuery.SetParameter("IsEmployee", isEmployee);
                var transformedQuery = sqlQuery.SetResultTransformer(new DataTableResultTransformer());
                return transformedQuery.List().OfType<DataTable>().Single();
            }
        }

        public DataTable GetAll()
        {
            var sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee FROM HR.EmployeeClassification ec;";

            using (var session = m_SessionFactory.OpenStatelessSession())
            {
                var sqlQuery = session.CreateSQLQuery(sql);
                var transformedQuery = sqlQuery.SetResultTransformer(new DataTableResultTransformer());
                return transformedQuery.List().OfType<DataTable>().Single();
            }
        }
    }
}
