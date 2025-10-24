using Recipes.Chain.Models;
using Recipes.Views;
using Tortuga.Chain;

namespace Recipes.Chain.Views
{
    public class ViewsScenario : IViewsScenario<EmployeeDetail, EmployeeSimple>
    {
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
            return m_DataSource.From<EmployeeDetail>(new { employeeClassificationKey }).ToCollection().Execute();
        }

        public IList<EmployeeDetail> FindByLastName(string lastName)
        {
            return m_DataSource.From<EmployeeDetail>(new { lastName }).ToCollection().Execute();
        }

        public EmployeeDetail? GetByEmployeeKey(int employeeKey)
        {
            return m_DataSource.From<EmployeeDetail>(new { employeeKey }).ToObjectOrNull().Execute();
        }

        public IEmployeeClassification? GetClassification(int employeeClassificationKey)
        {
            return m_DataSource.From<EmployeeClassification>(new { employeeClassificationKey }).ToObject().Execute();
        }
    }
}