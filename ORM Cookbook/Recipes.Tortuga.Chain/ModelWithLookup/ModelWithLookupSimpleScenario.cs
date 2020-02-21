using Recipes.Chain.Models;
using Recipes.ModelWithLookup;
using System;
using System.Collections.Generic;
using Tortuga.Chain;

namespace Recipes.Chain.ModelWithLookup
{
    public class ModelWithLookupSimpleScenario : IModelWithLookupSimpleScenario<EmployeeSimple>
    {
        const string TableName = "HR.Employee";
        readonly SqlServerDataSource m_DataSource;

        public ModelWithLookupSimpleScenario(SqlServerDataSource dataSource)
        {
            m_DataSource = dataSource;
        }

        public int Create(EmployeeSimple employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

            return m_DataSource.Insert(employee).ToInt32().Execute();
        }

        public void Delete(EmployeeSimple employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

            m_DataSource.Delete(employee).Execute();
        }

        public void DeleteByKey(int employeeKey)
        {
            m_DataSource.DeleteByKey(TableName, employeeKey).Execute();
        }

        public IList<EmployeeSimple> FindByLastName(string lastName)
        {
            throw new NotImplementedException();
        }

        public IList<EmployeeSimple> GetAll()
        {
            return m_DataSource.From<EmployeeSimple>().ToCollection().Execute();
        }

        public EmployeeSimple? GetByKey(int employeeKey)
        {
            return m_DataSource.GetByKey<EmployeeSimple>(employeeKey).ToObjectOrNull().Execute();
        }

        public IEmployeeClassification? GetClassification(int employeeClassificationKey)
        {
            return m_DataSource.GetByKey<EmployeeClassification>(employeeClassificationKey).ToObject().Execute();
        }

        public void Update(EmployeeSimple employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

            m_DataSource.Update(employee).Execute();
        }
    }
}
