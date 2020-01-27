using Recipes.Chain.Models;
using Recipes.Sorting;
using System.Collections.Generic;
using Tortuga.Chain;

namespace Recipes.Chain.Sorting
{
    public class SortingScenario : ISortingScenario<EmployeeSimple>
    {
        const string EmployeeTableName = "HR.Employee";
        readonly SqlServerDataSource m_DataSource;

        public SortingScenario(SqlServerDataSource dataSource)
        {
            m_DataSource = dataSource;
        }

        public void InsertBatch(IList<EmployeeSimple> employees)
        {
            m_DataSource.InsertBatch((IReadOnlyList<EmployeeSimple>)employees).Execute();
        }

        public IList<EmployeeSimple> SortByFirstName(string lastName)
        {
            return m_DataSource.From(EmployeeTableName, new { lastName }).WithSorting("FirstName").ToCollection<EmployeeSimple>().Execute();
        }

        public IList<EmployeeSimple> SortByMiddleNameDescFirstName(string lastName)
        {
            return m_DataSource.From(EmployeeTableName, new { lastName }).WithSorting(new SortExpression("MiddleName", SortDirection.Descending), "FirstName").ToCollection<EmployeeSimple>().Execute();
        }

        public IList<EmployeeSimple> SortByMiddleNameFirstName(string lastName)
        {
            return m_DataSource.From(EmployeeTableName, new { lastName }).WithSorting("MiddleName", "FirstName").ToCollection<EmployeeSimple>().Execute();
        }
    }
}
