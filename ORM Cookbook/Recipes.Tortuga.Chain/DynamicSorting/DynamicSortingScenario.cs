using Recipes.Chain.Models;
using Recipes.DynamicSorting;
using System.Collections.Generic;
using Tortuga.Chain;

namespace Recipes.Chain.DynamicSorting
{
    public class DynamicSortingScenario : IDynamicSortingScenario<EmployeeSimple>
    {
        const string EmployeeTableName = "HR.Employee";
        readonly SqlServerDataSource m_DataSource;

        public DynamicSortingScenario(SqlServerDataSource dataSource)
        {
            m_DataSource = dataSource;
        }

        public void InsertBatch(IList<EmployeeSimple> employees)
        {
            m_DataSource.InsertBatch((IReadOnlyList<EmployeeSimple>)employees).Execute();
        }

        public IList<EmployeeSimple> SortBy(string lastName, string sortByColumn, bool isDescending)
        {
            var sortDirection = isDescending ? SortDirection.Descending : SortDirection.Ascending;

            return m_DataSource.From(EmployeeTableName, new { lastName })
                .WithSorting(new SortExpression(sortByColumn, sortDirection))
                .ToCollection<EmployeeSimple>().Execute();
        }

        public IList<EmployeeSimple> SortBy(string lastName, string sortByColumnA, bool isDescendingA,
            string sortByColumnB, bool isDescendingB)
        {
            var sortDirectionA = isDescendingA ? SortDirection.Descending : SortDirection.Ascending;
            var sortDirectionB = isDescendingB ? SortDirection.Descending : SortDirection.Ascending;

            return m_DataSource.From(EmployeeTableName, new { lastName })
                .WithSorting(
                    new SortExpression(sortByColumnA, sortDirectionA),
                    new SortExpression(sortByColumnB, sortDirectionB))
                .ToCollection<EmployeeSimple>().Execute();
        }
    }
}
