using Recipes.Sorting;
using System;
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

        public int Create(EmployeeSimple employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

            return m_DataSource.Insert(employee).ToInt32().Execute();
        }

        public IList<EmployeeSimple> SortByLastName()
        {
            return m_DataSource.From(EmployeeTableName).WithSorting("LastName").ToCollection<EmployeeSimple>().Execute();
        }

        public IList<EmployeeSimple> SortByLastNameDescFirstName()
        {
            return m_DataSource.From(EmployeeTableName).WithSorting(new SortExpression("LastName", SortDirection.Descending), "FirstName").ToCollection<EmployeeSimple>().Execute();
        }

        public IList<EmployeeSimple> SortByLastNameFirstName()
        {
            return m_DataSource.From(EmployeeTableName).WithSorting("LastName", "FirstName").ToCollection<EmployeeSimple>().Execute();
        }
    }
}
