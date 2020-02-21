using Recipes.Chain.Models;
using Recipes.MultipleDB;
using System;
using System.Collections.Generic;
using Tortuga.Chain;

namespace Recipes.Chain.MultipleDB
{
    public class MultipleDBScenario : IMultipleDBScenario<EmployeeClassification>
    {
        const string TableName = "HR.EmployeeClassification";
        readonly IClass1DataSource m_DataSource;

        public MultipleDBScenario(IClass1DataSource dataSource)
        {
            m_DataSource = dataSource;
        }

        public int Create(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            return m_DataSource.Insert(classification).ToInt32().Execute();
        }

        public void Delete(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            m_DataSource.Delete(classification).Execute();
        }

        public void DeleteByKey(int employeeClassificationKey)
        {
            m_DataSource.DeleteByKey(TableName, employeeClassificationKey).Execute();
        }

        public EmployeeClassification FindByName(string employeeClassificationName)
        {
            return m_DataSource.From<EmployeeClassification>(new { employeeClassificationName })
                .ToObject().Execute();
        }

        public IList<EmployeeClassification> GetAll()
        {
            return m_DataSource.From<EmployeeClassification>().ToCollection().Execute();
        }

        public EmployeeClassification? GetByKey(int employeeClassificationKey)
        {
            return m_DataSource.GetByKey(TableName, employeeClassificationKey)
                .ToObjectOrNull<EmployeeClassification>().Execute();
        }

        public void Update(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            m_DataSource.Update(classification).Execute();
        }
    }
}
