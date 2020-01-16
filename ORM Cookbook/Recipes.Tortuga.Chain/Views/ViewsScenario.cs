using Recipes.Views;
using System;
using System.Collections.Generic;
using Tortuga.Chain;

namespace Recipes.Chain.Views
{
    public class ViewsScenario : IViewsScenario<EmployeeDetail, EmployeeSimple>
    {
        const string ClassificationTableName = "HR.EmployeeClassification";
        const string EmployeeDetailViewName = "HR.EmployeeDetail";
        readonly SqlServerDataSource m_DataSource;

        public ViewsScenario(SqlServerDataSource dataSource)
        {
            m_DataSource = dataSource;
        }

        public int Create(EmployeeSimple employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

            return m_DataSource.Insert(employee).ToInt32().Execute();
        }

        public IList<EmployeeDetail> FindByEmployeeClassificationKey(int employeeClassificationKey)
        {
            return m_DataSource.From(EmployeeDetailViewName, new { employeeClassificationKey }).ToCollection<EmployeeDetail>().Execute();
        }

        public IList<EmployeeDetail> FindByLastName(string lastName)
        {
            return m_DataSource.From(EmployeeDetailViewName, new { lastName }).ToCollection<EmployeeDetail>().Execute();
        }

        public IList<EmployeeDetail> GetAll()
        {
            return m_DataSource.From(EmployeeDetailViewName).ToCollection<EmployeeDetail>().Execute();
        }

        public EmployeeDetail? GetByEmployeeKey(int employeeKey)
        {
            return m_DataSource.From(EmployeeDetailViewName, new { employeeKey }).ToObject<EmployeeDetail>(RowOptions.AllowEmptyResults).Execute();
        }

        public IEmployeeClassification? GetClassification(int employeeClassificationKey)
        {
            return m_DataSource.From(ClassificationTableName, new { employeeClassificationKey }).ToObject<EmployeeClassification>().Execute();
        }
    }
}
